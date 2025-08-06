using ProperTea.Shared.Domain.DomainEvents;

namespace ProperTea.Shared.Domain
{
    public interface IAggregateRoot
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        void ClearDomainEvents();
    }
}
