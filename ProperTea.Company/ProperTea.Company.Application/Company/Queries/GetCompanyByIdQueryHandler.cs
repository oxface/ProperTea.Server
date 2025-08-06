using ProperTea.Company.Domain.Company;
using ProperTea.Company.Application.Company.Models;
using ProperTea.Shared.Application.Queries;

namespace ProperTea.Company.Application.Company.Queries
{
    public class GetCompanyByIdQueryHandler(ICompanyRepository repository)
        : IQueryHandler<GetCompanyByIdQuery, CompanyModel>
    {
        public async Task<CompanyModel> HandleAsync(GetCompanyByIdQuery query)
        {
            var company = await repository.GetByIdAsync(query.Id);
            if (company == null)
                throw new Exception("Company not found");
            return new CompanyModel { Id = company.Id, Name = company.Name };
        }
    }
}
