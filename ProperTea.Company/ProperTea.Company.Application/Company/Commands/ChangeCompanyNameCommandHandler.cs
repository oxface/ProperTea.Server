using ProperTea.Shared.Application.Commands;

namespace ProperTea.Company.Application.Company.Commands;

public class ChangeCompanyNameCommandHandler(ICompanyDomainService domainService, IUnitOfWork unitOfWork)
    : ICommandHandler<ChangeCompanyNameCommand>
{
    public async Task<object?> HandleAsync(ChangeCompanyNameCommand command)
    {
        await domainService.ChangeCompanyNameAsync(command.Id, command.NewName);
        await unitOfWork.SaveChangesAsync();
        return null;
    }
}