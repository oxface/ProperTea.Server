using ProperTea.Company.Domain.Company;
using ProperTea.Company.Domain.Company.DomainEvents;
using ProperTea.Company.Domain.Core;

namespace ProperTea.Company.Application.Company.DomainEventHandlers;

public class CompanyCreatedDomainEventHandler : IDomainEventHandler<CompanyCreatedDomainEvent>
{
    private readonly ICompanyDomainService _companyDomainService;

    public CompanyCreatedDomainEventHandler(ICompanyDomainService companyDomainService)
    {
        _companyDomainService = companyDomainService;
    }

    public async Task HandleAsync(CompanyCreatedDomainEvent domainEvent, CancellationToken ct = default)
    {
        // TODO: integration event.
        await _companyDomainService.ChangeCompanyNameAsync(domainEvent.CompanyId, domainEvent.Name + "1", ct);
    }
}
