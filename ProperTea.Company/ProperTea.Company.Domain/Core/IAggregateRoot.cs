using System.Collections.Generic;

namespace ProperTea.Company.Domain.Core
{
    public interface IAggregateRoot
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        void ClearDomainEvents();
    }
}
