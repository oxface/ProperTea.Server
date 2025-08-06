using ProperTea.Company.Domain.Company;
using ProperTea.Company.Domain.Company.DomainEvents;
using ProperTea.Shared.Domain.Exceptions;

namespace ProperTea.Company.Domain.CompanyAggregate;

public class CompanyDomainService(ICompanyRepository repository) : DomainServiceBase, ICompanyDomainService
{
    public async Task<Company> CreateCompanyAsync(string name,
        Guid systemOwnerId,
        CancellationToken ct = default)
    {
        var company = Company.Create(name, systemOwnerId);
        await repository.AddAsync(company, ct);
        return company;
    }

    public async Task DeleteCompanyAsync(Guid id, CancellationToken ct = default)
    {
        var company = await repository.GetByIdAsync(id, ct);
        if (company is null)
            throw new InvalidOperationException("Company not found");

        if (!company.AllowDelete())
            throw new InvalidOperationException("Company cannot be deleted");

        AddDomainEvent(new CompanyDeletedDomainEvent(company.Id));
        await repository.DeleteAsync(company, ct);
    }


    public async Task ChangeCompanyNameAsync(Guid id, string newName, CancellationToken ct = default)
    {
        var company = await repository.GetByIdAsync(id, ct);
        if (company == null) throw new EntityNotFoundException(nameof(Company), id);

        company.ChangeName(newName);
    }
}