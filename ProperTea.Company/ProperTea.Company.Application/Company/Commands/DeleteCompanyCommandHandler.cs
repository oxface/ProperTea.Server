using ProperTea.Company.Application.Core;
using System.Threading.Tasks;
using ProperTea.Company.Domain.Company;

namespace ProperTea.Company.Application.Company.Commands
{
    public class DeleteCompanyCommandHandler : ICommandHandler<DeleteCompanyCommand>
    {
        private readonly ICompanyDomainService _domainService;

        public DeleteCompanyCommandHandler(ICompanyDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<object?> HandleAsync(DeleteCompanyCommand command)
        {
            await _domainService.DeleteCompanyAsync(command.Id);
            return null;
        }
    }
}
