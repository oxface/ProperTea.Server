using ProperTea.Company.Domain.Company;
using ProperTea.Company.Application.Core;
using ProperTea.Company.Application.Company.Models;

namespace ProperTea.Company.Application.Company.Queries
{
    public class GetCompaniesByFilterQueryHandler : IQueryHandler<GetCompaniesByFilterQuery, IEnumerable<CompanyModel>>
    {
        private readonly ICompanyRepository _repository;

        public GetCompaniesByFilterQueryHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CompanyModel>> HandleAsync(GetCompaniesByFilterQuery query)
        {
            var companies = await _repository.GetByFilterAsync(query.Filter);
            return companies.Select(c => new CompanyModel
            {
                Id = c.Id,
                Name = c.Name,
                // Map other properties as needed
            });
        }
    }
}
