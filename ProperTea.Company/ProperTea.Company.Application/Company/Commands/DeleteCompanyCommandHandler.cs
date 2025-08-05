using ProperTea.Company.Application.Core;
using System.Threading.Tasks;
using ProperTea.Company.Domain.Company;

namespace ProperTea.Company.Application.Company.Commands
{
    public class DeleteCompanyCommandHandler : ICommandHandler<DeleteCompanyCommand>
    {
        private readonly ICompanyDomainService _domainService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompanyCommandHandler(ICompanyDomainService domainService, IUnitOfWork unitOfWork)
        {
            _domainService = domainService;
            _unitOfWork = unitOfWork;
        }

        public async Task<object?> HandleAsync(DeleteCompanyCommand command)
        {
            await _domainService.DeleteCompanyAsync(command.Id);
            await _unitOfWork.SaveChangesAsync();
            return null;
        }
    }
}
