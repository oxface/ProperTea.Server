namespace ProperTea.Company.Domain.Company;

public interface ICompanyDomainService : IDomainService
{
    Task<CompanyAggregate.Company> CreateCompanyAsync(string name, Guid systemOwnerId, CancellationToken ct = default);
    Task DeleteCompanyAsync(Guid id, CancellationToken ct = default);
    Task ChangeCompanyNameAsync(Guid id, string newName, CancellationToken ct = default);
}