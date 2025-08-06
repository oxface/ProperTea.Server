using ProperTea.Company.Domain.Core;

namespace ProperTea.Company.Domain.Company.DomainEvents
{
    public class CompanyDeletedDomainEvent(Guid companyId) : IDomainEvent
    {
        public Guid CompanyId { get; } = companyId;
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}
