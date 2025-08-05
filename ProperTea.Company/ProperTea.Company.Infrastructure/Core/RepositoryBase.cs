using Microsoft.EntityFrameworkCore;

using ProperTea.Company.Domain.Core;

namespace ProperTea.Company.Infrastructure.Core
{
    public abstract class AggregateRootRepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbContext _context;

        protected AggregateRootRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await IncludeRelatedData(_context.Set<T>())
                .SingleOrDefaultAsync(i => i.Id == id, ct);
        }

        public virtual async Task AddAsync(T entity, CancellationToken ct = default)
        {
            await _context.Set<T>().AddAsync(entity, ct);
        }

        public virtual async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _context.Set<T>().FindAsync(id, ct) ?? throw new Exception();
            _context.Set<T>().Remove(entity);
        }

        public virtual async Task DeleteAsync(T entity, CancellationToken ct = default)
        {
            await DeleteAsync(entity.Id, ct);
        }

        protected virtual IQueryable<T> IncludeRelatedData(IQueryable<T> queryable)
            => queryable;
    }
}
