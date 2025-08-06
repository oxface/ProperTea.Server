using ProperTea.Company.Domain.Company.DomainEvents;
using ProperTea.Company.Domain.Core;

namespace ProperTea.Company.Domain.Company
{
    public class CompanyDomainService : DomainServiceBase, ICompanyDomainService
    {
        private readonly ICompanyRepository _repository;

        public CompanyDomainService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company> CreateCompanyAsync(string name,
         CancellationToken ct = default)
        {
            var company = Company.Create(name);
            await _repository.AddAsync(company, ct);
            return company;
        }

        public async Task DeleteCompanyAsync(Guid id, CancellationToken ct = default)
        {
            var company = await _repository.GetByIdAsync(id);
            if (company is null)
                throw new InvalidOperationException("Company not found");

            if (!company.AllowDelete())
                throw new InvalidOperationException("Company cannot be deleted");

            AddDomainEvent(new CompanyDeletedDomainEvent(company.Id));
            await _repository.DeleteAsync(company);
        }


        public async Task ChangeCompanyNameAsync(Guid id, string newName, CancellationToken ct = default)
        {
            var company = await _repository.GetByIdAsync(id);
            if (company != null)
            {
                company.ChangeName(newName);
            }
        }
    }
}
