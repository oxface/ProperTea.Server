namespace ProperTea.Company.Domain.Core;

public abstract class DomainServiceBase : IDomainService
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public IEnumerable<IDomainEvent> GetAllDomainEventsAndClear()
    {
        var events = _domainEvents.ToList();
        ClearDomainEvents();
        return events;
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
