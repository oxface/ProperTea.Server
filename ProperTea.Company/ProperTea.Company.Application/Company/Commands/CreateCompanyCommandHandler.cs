using ProperTea.Company.Application.Core;
using System.Threading.Tasks;
using ProperTea.Company.Domain.Company;

namespace ProperTea.Company.Application.Company.Commands
{
    public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, Guid>
    {
        private readonly ICompanyDomainService _domainService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompanyCommandHandler(ICompanyDomainService domainService, IUnitOfWork unitOfWork)
        {
            _domainService = domainService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> HandleAsync(CreateCompanyCommand command)
        {
            var company = await _domainService.CreateCompanyAsync(command.Name);
            await _unitOfWork.SaveChangesAsync();
            return company.Id;
        }
    }
}
