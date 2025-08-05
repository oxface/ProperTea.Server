using System.Threading.Tasks;

namespace ProperTea.Company.Application.Core
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
