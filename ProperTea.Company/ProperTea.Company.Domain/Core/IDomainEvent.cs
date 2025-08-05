using System;

namespace ProperTea.Company.Domain.Core
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
