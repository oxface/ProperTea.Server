using ProperTea.Company.Application.Core;
using ProperTea.Company.Application.Company.Models;

namespace ProperTea.Company.Application.Company.Queries
{
    public class GetCompanyByIdQuery : IQuery<CompanyModel>
    {
        public Guid Id { get; set; }
    }
}
