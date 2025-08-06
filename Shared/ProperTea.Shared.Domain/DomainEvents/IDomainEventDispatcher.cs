namespace ProperTea.Shared.Domain.DomainEvents;

public interface IDomainEventDispatcher
{
    Task DispatchAllAsync(CancellationToken cancellationToken = default);
    void Enqueue(IDomainEvent domainEvent);
}