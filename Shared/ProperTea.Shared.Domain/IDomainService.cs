using ProperTea.Shared.Domain.DomainEvents;

namespace ProperTea.Shared.Domain;

public interface IDomainService
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}