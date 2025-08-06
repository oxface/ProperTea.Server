using ProperTea.Shared.Application.Commands;

namespace ProperTea.Company.Application.Company.Commands;

public class CreateCompanyCommandHandler(ICompanyDomainService domainService, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCompanyCommand, Guid>
{
    public async Task<Guid> HandleAsync(CreateCompanyCommand command)
    {
        var company = await domainService.CreateCompanyAsync(command.Name);
        await unitOfWork.SaveChangesAsync();
        return company.Id;
    }
}