namespace ProperTea.Shared.Domain.DomainEvents;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}

public interface IPrioritizedDomainEvent : IDomainEvent
{
    int Priority { get; }
}