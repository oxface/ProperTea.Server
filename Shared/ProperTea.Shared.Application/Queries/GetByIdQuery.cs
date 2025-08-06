namespace ProperTea.Shared.Application.Queries;

public class GetByIdQuery<TModel> : IQuery<TModel>
    where TModel : class
{
    public Guid Id { get; set; }
}