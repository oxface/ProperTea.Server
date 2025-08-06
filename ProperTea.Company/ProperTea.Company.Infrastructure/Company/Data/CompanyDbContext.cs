using Microsoft.EntityFrameworkCore;

using ProperTea.Shared.Domain;

namespace ProperTea.Company.Infrastructure.Company.Data;

public class CompanyDbContext(DbContextOptions<CompanyDbContext> options) : DbContext(options)
{
    public DbSet<Domain.CompanyAggregate.Company> Companies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.CompanyAggregate.Company>().HasIndex(
                nameof(Domain.CompanyAggregate.Company.Name), nameof(Domain.CompanyAggregate.Company.SystemOwnerId))
            .IsUnique()
            .HasDatabaseName("IX_Company_Name");

        modelBuilder.Entity<Domain.CompanyAggregate.Company>().Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            if (typeof(ISystemOwnerEntity).IsAssignableFrom(entityType.ClrType))
                modelBuilder.Entity(entityType.ClrType)
                    .HasIndex(nameof(ISystemOwnerEntity.SystemOwnerId));
    }
}