using ProperTea.Company.Domain.Company;
using ProperTea.Company.Application.Core;
using ProperTea.Company.Application.Company.Models;

namespace ProperTea.Company.Application.Company.Queries
{
    public class GetCompaniesByFilterQuery : IQuery<IEnumerable<CompanyModel>>
    {
        public CompanyFilter Filter { get; set; } = new();
    }
}
