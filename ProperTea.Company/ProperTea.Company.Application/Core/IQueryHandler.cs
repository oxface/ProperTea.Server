using System.Threading.Tasks;

namespace ProperTea.Company.Application.Core
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
