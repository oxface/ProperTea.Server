namespace ProperTea.Company.Domain.Company;

public interface ICompanyRepository : IRepository<CompanyAggregate.Company>
{
    Task<IEnumerable<CompanyAggregate.Company>> GetByFilterAsync(CompanyFilter filter, CancellationToken ct = default);
}