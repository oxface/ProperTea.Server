using ProperTea.Company.Domain.Core;

namespace ProperTea.Company.Domain.Company
{
    public interface ICompanyDomainService : IDomainService
    {
        Task<Company> CreateCompanyAsync(string name, CancellationToken ct = default);
        Task DeleteCompanyAsync(Guid id, CancellationToken ct = default);
        Task ChangeCompanyNameAsync(Guid id, string newName, CancellationToken ct = default);
    }
}
