using ProperTea.Company.Application.Core;
using System.Threading.Tasks;
using ProperTea.Company.Domain.Company;

namespace ProperTea.Company.Application.Company.Commands
{
    public class ChangeCompanyNameCommandHandler : ICommandHandler<ChangeCompanyNameCommand>
    {
        private readonly ICompanyDomainService _domainService;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeCompanyNameCommandHandler(ICompanyDomainService domainService, IUnitOfWork unitOfWork)
        {
            _domainService = domainService;
            _unitOfWork = unitOfWork;           
        }

        public async Task<object?> HandleAsync(ChangeCompanyNameCommand command)
        {
            await _domainService.ChangeCompanyNameAsync(command.Id, command.NewName);
            await _unitOfWork.SaveChangesAsync();
            return null;
        }
    }
}
