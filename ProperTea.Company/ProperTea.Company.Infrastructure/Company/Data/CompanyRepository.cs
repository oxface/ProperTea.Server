using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ProperTea.Company.Domain.Company;
using ProperTea.Company.Domain.Company.DomainEvents;
using ProperTea.Company.Infrastructure.Core;

namespace ProperTea.Company.Infrastructure.Company.Data
{
    public class CompanyRepository : AggregateRootRepositoryBase<Domain.Company.Company>, ICompanyRepository
    {
        private CompanyDbContext _context;

        public CompanyRepository(CompanyDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Company.Company>> GetByFilterAsync(CompanyFilter filter, CancellationToken ct = default)
        {
            var items = _context.Companies.AsQueryable();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                items = items.Where(i => i.Name.Contains(filter.Name));
            }

            return await IncludeRelatedData(items).ToListAsync(ct);
        }
    }
}
