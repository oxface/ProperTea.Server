using ProperTea.Company.Domain.Core;

using System;

namespace ProperTea.Company.Domain.Company.DomainEvents
{
    public class CompanyNameChangedDomainEvent : IDomainEvent
    {
        public Guid CompanyId { get; }
        public string NewName { get; }
        public DateTime OccurredOn { get; }

        public CompanyNameChangedDomainEvent(Guid companyId, string newName)
        {
            CompanyId = companyId;
            NewName = newName;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
