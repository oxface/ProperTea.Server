using System;
using System.Threading.Tasks;

using ProperTea.Company.Domain.Core;

namespace ProperTea.Company.Domain.Company
{
    public interface ICompanyDomainService : Core.IDomainService
    {
        Task<Company> CreateCompanyAsync(string name, CancellationToken ct = default);
        Task DeleteCompanyAsync(Guid id, CancellationToken ct = default);
        Task ChangeCompanyNameAsync(Guid id, string newName, CancellationToken ct = default);
    }
}
