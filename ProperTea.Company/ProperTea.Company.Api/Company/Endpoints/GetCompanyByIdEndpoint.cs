using Microsoft.AspNetCore.Http;
using ProperTea.Company.Application.Company.Models;
using ProperTea.Company.Application.Company.Queries;
using ProperTea.Company.Application.Core;

namespace ProperTea.Company.Api.Company.Endpoints
{
    public static class GetCompanyByIdEndpoint
    {
        public static void Map(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/company/{id:guid}", async (Guid id, IQueryHandler<GetCompanyByIdQuery, CompanyModel> handler) =>
            {
                var result = await handler.HandleAsync(new GetCompanyByIdQuery { Id = id });
                return result is not null ? Results.Ok(result) : Results.NotFound();
            });
        }
    }
}
