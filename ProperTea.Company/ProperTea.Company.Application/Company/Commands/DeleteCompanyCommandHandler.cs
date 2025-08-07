using ProperTea.Company.Domain.Company;
using ProperTea.Shared.Application.Commands;

namespace ProperTea.Company.Application.Company.Commands;

public class DeleteCompanyCommandHandler(ICompanyDomainService domainService, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteCompanyCommand>
{
    public async Task<object?> HandleAsync(DeleteCompanyCommand command)
    {
        await domainService.DeleteCompanyAsync(command.Id);
        await unitOfWork.SaveChangesAsync();
        return null;
    }
}