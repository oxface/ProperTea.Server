using Microsoft.EntityFrameworkCore;

namespace ProperTea.Company.Infrastructure.Company.Data;

public class CompanyDbContext(DbContextOptions<CompanyDbContext> options) : DbContext(options)
{
    public DbSet<Domain.Company.Company> Companies { get; set; }
}