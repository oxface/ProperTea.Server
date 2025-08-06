using ProperTea.Shared.Application.Commands;

namespace ProperTea.Company.Application.Company.Commands
{
    public class DeleteCompanyCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
