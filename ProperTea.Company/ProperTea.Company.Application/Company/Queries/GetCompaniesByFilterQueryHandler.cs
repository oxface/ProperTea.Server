using ProperTea.Company.Application.Company.Models;
using ProperTea.Shared.Application.Queries;

namespace ProperTea.Company.Application.Company.Queries;

public class GetCompaniesByFilterQueryHandler(ICompanyRepository repository)
    : IQueryHandler<GetCompaniesByFilterQuery, IEnumerable<CompanyModel>>
{
    public async Task<IEnumerable<CompanyModel>> HandleAsync(GetCompaniesByFilterQuery query)
    {
        var companies = await repository.GetByFilterAsync(query.Filter);
        return companies.Select(c => new CompanyModel
        {
            Id = c.Id,
            Name = c.Name
        });
    }
}