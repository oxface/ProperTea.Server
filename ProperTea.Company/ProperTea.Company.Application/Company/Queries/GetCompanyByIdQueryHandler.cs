using ProperTea.Company.Application.Core;
using System.Threading.Tasks;
using ProperTea.Company.Domain.Company;
using ProperTea.Company.Application.Company.Models;

namespace ProperTea.Company.Application.Company.Queries
{
    public class GetCompanyByIdQueryHandler : IQueryHandler<GetCompanyByIdQuery, CompanyModel>
    {
        private readonly ICompanyRepository _repository;

        public GetCompanyByIdQueryHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<CompanyModel> HandleAsync(GetCompanyByIdQuery query)
        {
            var company = await _repository.GetByIdAsync(query.Id);
            if (company == null)
                throw new Exception("Company not found");
            return new CompanyModel { Id = company.Id, Name = company.Name };
        }
    }
}
