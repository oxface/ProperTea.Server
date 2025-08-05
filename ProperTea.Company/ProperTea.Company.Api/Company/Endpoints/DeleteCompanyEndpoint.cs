using Microsoft.AspNetCore.Http;
using ProperTea.Company.Application.Company.Commands;
using ProperTea.Company.Application.Core;

namespace ProperTea.Company.Api.Company.Endpoints
{
    public static class DeleteCompanyEndpoint
    {
        public static void Map(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapDelete("/company/{id:guid}", async (Guid id, ICommandHandler<DeleteCompanyCommand> handler) =>
            {
                await handler.HandleAsync(new DeleteCompanyCommand { Id = id });
                return Results.NoContent();
            });
        }
    }
}
