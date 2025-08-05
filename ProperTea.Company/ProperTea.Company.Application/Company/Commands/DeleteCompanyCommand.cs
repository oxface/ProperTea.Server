using ProperTea.Company.Application.Core;
using System;

namespace ProperTea.Company.Application.Company.Commands
{
    public class DeleteCompanyCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
