using ProperTea.Company.Application.Core;
using System;

namespace ProperTea.Company.Application.Company.Commands
{
    public class ChangeCompanyNameCommand : ICommand
    {
        public Guid Id { get; set; }
        public string NewName { get; set; } = string.Empty;
    }
}
