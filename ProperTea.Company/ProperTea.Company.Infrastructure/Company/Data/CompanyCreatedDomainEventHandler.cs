using System;

using ProperTea.Company.Domain.Company;
using ProperTea.Company.Domain.Core;

namespace ProperTea.Company.Infrastructure.Company.Data;

public class CompanyCreatedDomainEventHandler : IDomainEventHandler<CompanyCreatedDomainEvent>
{
    public Task HandleAsync(CompanyCreatedDomainEvent domainEvent, CancellationToken ct = default)
    {
        // TODO: integration event.
        return Task.CompletedTask;
    }
}
