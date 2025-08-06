using ProperTea.Company.Domain.Company;
using ProperTea.Company.Application.Company.Models;
using ProperTea.Company.Application.Company.Queries;
using ProperTea.Shared.Application.Queries;

namespace ProperTea.Company.Api.Company.Endpoints
{
    public static class GetCompaniesEndpoint
    {
        public static void Map(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/company",
                async (HttpRequest request, IQueryHandler<GetCompaniesByFilterQuery, IEnumerable<CompanyModel>> handler) =>
                {
                    var filter = new CompanyFilter
                    {
                        Name = request.Query["name"]
                    };
                    var query = new GetCompaniesByFilterQuery { Filter = filter };
                    var result = await handler.HandleAsync(query);
                    return Results.Ok(result);
                });
        }
    }
}
