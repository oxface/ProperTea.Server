namespace ProperTea.Shared.Domain.Exceptions;

public class EntityNotFoundException(string entityName, object id)
    : DomainException($"{entityName} with id {id} was not found.")
{
    public string EntityName { get; } = entityName;
    public object Id { get; } = id;
}