namespace ProperTea.Company.Domain.Core
{
    public interface IDomainService
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
        void ClearDomainEvents();
    }
}
