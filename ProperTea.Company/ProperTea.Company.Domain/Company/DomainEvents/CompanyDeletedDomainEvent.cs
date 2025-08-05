using ProperTea.Company.Domain.Core;
using System;

namespace ProperTea.Company.Domain.Company
{
    public class CompanyDeletedDomainEvent : IDomainEvent
    {
        public Guid CompanyId { get; }
        public DateTime OccurredOn { get; }

        public CompanyDeletedDomainEvent(Guid companyId)
        {
            CompanyId = companyId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
