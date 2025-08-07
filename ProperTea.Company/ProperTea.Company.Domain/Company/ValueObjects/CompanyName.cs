using ProperTea.Shared.Domain.Exceptions;

namespace ProperTea.Company.Domain.Company.ValueObjects;

public record CompanyName
{
    private CompanyName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static CompanyName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Company.NameRequired");

        if (value.Length > Company.MaxNameLength)
            throw new DomainException("Company.NameTooLong");

        if (value.Length < Company.MinNameLength)
            throw new DomainException("Company.NameTooShort");

        return new CompanyName(value);
    }

    public static implicit operator string(CompanyName name)
    {
        return name.Value;
    }

    public static explicit operator CompanyName(string value)
    {
        return Create(value);
    }
}