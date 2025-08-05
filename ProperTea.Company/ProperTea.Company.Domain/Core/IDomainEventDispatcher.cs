using System;

namespace ProperTea.Company.Domain.Core;

public interface IDomainEventDispatcher
{
    Task DispatchAllAsync(CancellationToken cancellationToken = default);
    void Enqueue(IDomainEvent domainEvent);
}