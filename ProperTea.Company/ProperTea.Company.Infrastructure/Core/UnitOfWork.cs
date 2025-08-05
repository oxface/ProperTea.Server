using System.Runtime.CompilerServices;

using Microsoft.EntityFrameworkCore;

using ProperTea.Company.Application.Core;
using ProperTea.Company.Domain.Core;
using ProperTea.Company.Infrastructure.Company.Data;

namespace ProperTea.Company.Infrastructure.Core;

public class UnitOfWork : IUnitOfWork
{
    private readonly CompanyDbContext _dbContext;
    private readonly IDomainEventDispatcher _dispatcher;

    public UnitOfWork(CompanyDbContext dbContext, IDomainEventDispatcher dispatcher)
    {
        _dbContext = dbContext;
        _dispatcher = dispatcher;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            // Save data so the events have access to the latest state.
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            
            var iterationsLimit = 20;
            var currentIteration = 0;
            bool hasMoreEvents;
            do
            {
                var domainEvents = CollectDomainEvents();
                ClearDomainEvents();
                
                foreach (var domainEvent in domainEvents)
                    _dispatcher.Enqueue(domainEvent);

                await _dispatcher.DispatchAllAsync(cancellationToken);
                
                if (_dbContext.ChangeTracker.HasChanges())
                {
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }

                hasMoreEvents = CollectDomainEvents().Any();
                currentIteration++;
            } while (hasMoreEvents && currentIteration < iterationsLimit);

            await transaction.CommitAsync(cancellationToken);
            return result;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
    
    private IEnumerable<IDomainEvent> CollectDomainEvents()
    {
        var domainEvents = _dbContext.ChangeTracker
            .Entries<IAggregateRoot>()
            .SelectMany(e => e.Entity.DomainEvents);
        return domainEvents.ToList();
    }
    
    private void ClearDomainEvents()
    {
        foreach (var entity in _dbContext.ChangeTracker.Entries<IAggregateRoot>())
            entity.Entity.ClearDomainEvents();
    }
}
