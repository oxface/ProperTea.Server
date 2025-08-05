using System;
using System.Threading.Tasks;

namespace ProperTea.Company.Domain.Core
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task AddAsync(T entity, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
        Task DeleteAsync(T entity, CancellationToken ct = default);
    }
}
