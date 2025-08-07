using Microsoft.EntityFrameworkCore;

using ProperTea.Company.Infrastructure.Company.ValueConverters;
using ProperTea.Shared.Domain;

namespace ProperTea.Company.Infrastructure.Company.Data;

public class CompanyDbContext(DbContextOptions<CompanyDbContext> options) : DbContext(options)
{
    public DbSet<Domain.Company.Company> Companies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Company.Company>(builder =>
        {
            builder.Property(c => c.Name)
                .HasConversion(new CompanyNameConverter())
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(nameof(Domain.Company.Company.Name),
                    nameof(Domain.Company.Company.SystemOwnerId))
                .IsUnique()
                .HasDatabaseName("IX_Company_Name");
        });

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            if (typeof(ISystemOwnerEntity).IsAssignableFrom(entityType.ClrType))
                modelBuilder.Entity(entityType.ClrType)
                    .HasIndex(nameof(ISystemOwnerEntity.SystemOwnerId));
    }
}