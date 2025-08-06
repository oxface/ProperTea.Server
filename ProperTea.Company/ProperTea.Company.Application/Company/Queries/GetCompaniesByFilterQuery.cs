using ProperTea.Company.Application.Company.Models;
using ProperTea.Shared.Application.Queries;

namespace ProperTea.Company.Application.Company.Queries;

public class GetCompaniesByFilterQuery : IQuery<IEnumerable<CompanyModel>>
{
    public CompanyFilter Filter { get; set; } = new();
}