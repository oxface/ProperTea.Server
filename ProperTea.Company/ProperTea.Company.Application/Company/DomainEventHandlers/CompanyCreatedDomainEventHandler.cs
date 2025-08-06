using ProperTea.Company.Domain.Company;
using ProperTea.Company.Domain.Company.DomainEvents;
using ProperTea.Shared.Domain.DomainEvents;

namespace ProperTea.Company.Application.Company.DomainEventHandlers;

public class CompanyCreatedDomainEventHandler(ICompanyDomainService companyDomainService)
    : IDomainEventHandler<CompanyCreatedDomainEvent>
{
    public async Task HandleAsync(CompanyCreatedDomainEvent domainEvent, CancellationToken ct = default)
    {
        // TODO: integration event.
        await companyDomainService.ChangeCompanyNameAsync(domainEvent.CompanyId, domainEvent.Name + "1", ct);
    }
}
