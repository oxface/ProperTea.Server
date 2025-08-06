using ProperTea.Shared.Domain.DomainEvents;

namespace ProperTea.Company.Domain.Company.DomainEvents;

public class CompanyDeletedDomainEvent(Guid companyId) : IDomainEvent
{
    public Guid CompanyId { get; } = companyId;
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}