using ProperTea.Shared.Application.Commands;

namespace ProperTea.Company.Application.Company.Commands
{
    public class CreateCompanyCommand : ICommand
    {
        public string Name { get; set; } = string.Empty;
    }
}
