using ProperTea.Company.Application.Core;

namespace ProperTea.Company.Application.Company.Commands
{
    public class CreateCompanyCommand : ICommand
    {
        public string Name { get; set; } = string.Empty;
    }
}
