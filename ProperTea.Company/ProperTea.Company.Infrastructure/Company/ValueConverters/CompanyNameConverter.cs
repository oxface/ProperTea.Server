using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using ProperTea.Company.Domain.Company.ValueObjects;

namespace ProperTea.Company.Infrastructure.Company.ValueConverters;

public class CompanyNameConverter() : ValueConverter<CompanyName, string>(
    v => v.Value,
    v => CompanyName.Create(v));