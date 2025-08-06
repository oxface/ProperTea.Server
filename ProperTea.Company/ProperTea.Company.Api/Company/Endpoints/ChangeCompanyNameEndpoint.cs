using ProperTea.Company.Application.Company.Commands;
using ProperTea.Shared.Application.Commands;

namespace ProperTea.Company.Api.Company.Endpoints;

public static class ChangeCompanyNameEndpoint
{
    public static void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut("/company/{id:guid}/name",
            async (ChangeCompanyNameCommand command, ICommandHandler<ChangeCompanyNameCommand> handler) =>
            {
                await handler.HandleAsync(command);
                return Results.NoContent();
            });
    }
}