using ProperTea.Company.Domain.Core;

namespace ProperTea.Company.Domain.Company.DomainEvents
{
    public class CompanyNameChangedDomainEvent(Guid companyId, string newName) : IDomainEvent
    {
        public Guid CompanyId { get; } = companyId;
        public string NewName { get; } = newName;
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}
