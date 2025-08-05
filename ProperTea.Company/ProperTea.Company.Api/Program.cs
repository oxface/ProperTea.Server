using Dapr.Client;
using Dapr.AspNetCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Scalar.AspNetCore;
using ProperTea.Company.Api.Setup;
using ProperTea.Company.Api.Company.Endpoints;
using ProperTea.Company.MigrationService;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

if (!builder.Environment.IsDevelopment())
{
    var keyVaultEndpoint = builder.Configuration["KeyVaultEndpoint"];
    if (!string.IsNullOrEmpty(keyVaultEndpoint))
    {
        builder.Configuration.AddAzureKeyVault(keyVaultEndpoint);
    }
}
builder.Services
    .AddDomainServices()
    .AddDataServices(builder.Configuration)
    .AddInfrastructureServices()
    .AddApplicationServices();

// Add Dapr services
builder.Services.AddDaprClient();
builder.Services.AddControllers().AddDapr();

builder.Services.AddOpenApi();

builder.Services.ConfigureHttpJsonOptions(options => {
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

// Use Dapr middleware
app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapOpenApi();
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapDefaultEndpoints()
    .MapCompanyEndpoints();

app.Run();