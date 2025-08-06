namespace ProperTea.Company.Domain.Company;

public interface ICompanyRepository : IRepository<Company>
{
    Task<IEnumerable<Company>> GetByFilterAsync(CompanyFilter filter, CancellationToken ct = default);
}