using ProperTea.Company.Application.Core;
using System.Threading.Tasks;
using ProperTea.Company.Domain.Company;

namespace ProperTea.Company.Application.Company.Commands
{
    public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, Guid>
    {
        private readonly ICompanyDomainService _domainService;

        public CreateCompanyCommandHandler(ICompanyDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<Guid> HandleAsync(CreateCompanyCommand command)
        {
            var company = await _domainService.CreateCompanyAsync(command.Name);
            return company.Id;
        }
    }
}
