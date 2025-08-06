using Microsoft.EntityFrameworkCore;

using ProperTea.Shared.Infrastructure.Data;

namespace ProperTea.Company.Infrastructure.Company.Data;

public class CompanyRepository(CompanyDbContext context)
    : RepositoryEfBase<Domain.CompanyAggregate.Company>(context), ICompanyRepository
{
    public async Task<IEnumerable<Domain.CompanyAggregate.Company>> GetByFilterAsync(
        CompanyFilter filter,
        CancellationToken ct = default)
    {
        var items = context.Companies.AsQueryable();
        if (!string.IsNullOrEmpty(filter.Name)) items = items.Where(i => i.Name.Contains(filter.Name));

        return await IncludeRelatedData(items).ToListAsync(ct);
    }
}