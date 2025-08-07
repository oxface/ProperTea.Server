using ProperTea.Shared.Domain.Exceptions;

namespace ProperTea.Shared.Domain.ValueObjects;

public readonly record struct SystemOwner
{
    private SystemOwner(Guid id)
    {
        if (id == Guid.Empty)
            throw new DomainException("SystemOwner ID cannot be empty");
        Id = id;
    }

    public Guid Id { get; }

    public static SystemOwner Create(Guid id)
    {
        return new SystemOwner(id);
    }
}