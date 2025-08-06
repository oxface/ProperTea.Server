namespace ProperTea.Company.Domain.Core
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
    
    public interface IPrioritizedDomainEvent : IDomainEvent
    {
        int Priority { get; }
    }
}
