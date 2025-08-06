using System.Text.Json.Serialization;
using Scalar.AspNetCore;
using ProperTea.Company.Api.Setup;
using ProperTea.Company.Api.Company.Endpoints;
using ProperTea.Shared.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddGlobalErrorHandling();

builder.Services
    .AddDomainServices()
    .AddDataServices(builder.Configuration)
    .AddInfrastructureServices()
    .AddApplicationServices();

builder.Services.AddDaprClient();
builder.Services.AddControllers().AddDapr();

builder.Services.AddOpenApi();

builder.Services.ConfigureHttpJsonOptions(options => {
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapOpenApi();
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.UseExceptionHandler();
app.UseStatusCodePages();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.MapDefaultEndpoints()
    .MapCompanyEndpoints();

app.Run();