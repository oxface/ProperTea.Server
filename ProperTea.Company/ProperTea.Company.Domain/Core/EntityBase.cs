using System;

namespace ProperTea.Company.Domain.Core
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
    }
}
