using ProperTea.Company.Domain.Core;
using System;

namespace ProperTea.Company.Domain.Company
{
    public class CompanyCreatedDomainEvent : IDomainEvent
    {
        public Guid CompanyId { get; }
        public string Name { get; }
        public DateTime OccurredOn { get; }

        public CompanyCreatedDomainEvent(Guid companyId, string name)
        {
            CompanyId = companyId;
            Name = name;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
