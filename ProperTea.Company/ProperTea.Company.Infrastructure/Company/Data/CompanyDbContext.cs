using System;

using Microsoft.EntityFrameworkCore;

namespace ProperTea.Company.Infrastructure.Company.Data;

public class CompanyDbContext : DbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Company.Company> Companies { get; set; }
}
