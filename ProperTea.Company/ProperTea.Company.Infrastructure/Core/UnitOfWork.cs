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
        var domainEvents = _dbContext.ChangeTracker
            .Entries<IAggregateRoot>()
            .SelectMany(e => e.Entity.DomainEvents)
            .ToList();

        foreach (var entity in _dbContext.ChangeTracker.Entries<IAggregateRoot>())
            entity.Entity.ClearDomainEvents();

        foreach (var domainEvent in domainEvents)
            _dispatcher.Enqueue(domainEvent);

        await _dispatcher.DispatchAllAsync(cancellationToken);

        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
