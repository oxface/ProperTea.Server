using ProperTea.Company.Application.Company.Commands;
using ProperTea.Shared.Application.Commands;

namespace ProperTea.Company.Api.Company.Endpoints;

public static class CreateCompanyEndpoint
{
    public static void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/company",
            async (CreateCompanyCommand command, ICommandHandler<CreateCompanyCommand, Guid> handler) =>
            {
                var result = await handler.HandleAsync(command);
                return Results.Created($"/companies/{result}", result);
            });
    }
}