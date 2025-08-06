using ProperTea.Company.Application.Core;
using ProperTea.Company.Domain.Core;
using ProperTea.Company.Infrastructure.Company.Data;

namespace ProperTea.Company.Infrastructure.Core;

public class UnitOfWork(CompanyDbContext dbContext, IDomainEventDispatcher dispatcher)
    : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            // Save data so the events have access to the latest state.
            var result = await dbContext.SaveChangesAsync(cancellationToken);
            
            var iterationsLimit = 20;
            var currentIteration = 0;
            bool hasMoreEvents;
            do
            {
                var domainEvents = CollectDomainEvents();
                ClearDomainEvents();
                
                foreach (var domainEvent in domainEvents)
                    dispatcher.Enqueue(domainEvent);

                await dispatcher.DispatchAllAsync(cancellationToken);
                
                if (dbContext.ChangeTracker.HasChanges())
                {
                    await dbContext.SaveChangesAsync(cancellationToken);
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
        var domainEvents = dbContext.ChangeTracker
            .Entries<IAggregateRoot>()
            .SelectMany(e => e.Entity.DomainEvents);
        return domainEvents.ToList();
    }
    
    private void ClearDomainEvents()
    {
        foreach (var entity in dbContext.ChangeTracker.Entries<IAggregateRoot>())
            entity.Entity.ClearDomainEvents();
    }
}
