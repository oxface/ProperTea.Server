using Microsoft.EntityFrameworkCore;

using ProperTea.Shared.Domain;

namespace ProperTea.Shared.Infrastructure.Data;

public abstract class RepositoryEfBase<T>(DbContext context) : IRepository<T>
    where T : EntityBase
{
    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await IncludeRelatedData(context.Set<T>())
            .SingleOrDefaultAsync(i => i.Id == id, ct);
    }

    public virtual async Task AddAsync(T entity, CancellationToken ct = default)
    {
        await context.Set<T>().AddAsync(entity, ct);
    }

    public virtual async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await context.Set<T>()
                         .SingleOrDefaultAsync(i => i.Id == id, ct)
                     ?? throw new Exception();
        context.Set<T>().Remove(entity);
    }

    public virtual async Task DeleteAsync(T entity, CancellationToken ct = default)
    {
        await DeleteAsync(entity.Id, ct);
    }

    protected virtual IEnumerable<string> GetNavigationalProperties()
    {
        return [];
    }

    protected IQueryable<T> IncludeRelatedData(IQueryable<T> query)
    {
        return GetNavigationalProperties().Aggregate(query, (current, property)
            => current.Include(property));
    }
}