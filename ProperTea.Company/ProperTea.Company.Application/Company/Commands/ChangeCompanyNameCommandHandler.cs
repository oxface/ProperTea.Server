using ProperTea.Company.Application.Core;
using System.Threading.Tasks;
using ProperTea.Company.Domain.Company;

namespace ProperTea.Company.Application.Company.Commands
{
    public class ChangeCompanyNameCommandHandler : ICommandHandler<ChangeCompanyNameCommand>
    {
        private readonly ICompanyDomainService _domainService;

        public ChangeCompanyNameCommandHandler(ICompanyDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<object?> HandleAsync(ChangeCompanyNameCommand command)
        {
            await _domainService.ChangeCompanyNameAsync(command.Id, command.NewName);
            return null;
        }
    }
}
