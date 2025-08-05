using CommunityToolkit.Aspire.Hosting.Dapr;

var builder = DistributedApplication.CreateBuilder(args);

var companyApiSidecarOptions = new DaprSidecarOptions
{
    AppId = "company-api-sidecar",
    AppPort = 5000,
    DaprHttpPort = 5010,
    DaprGrpcPort = 5011,
    MetricsPort = 5012
};
var companyApi = builder
        .AddProject<Projects.ProperTea_Company_Api>("company-api")
        .WithDaprSidecar(companyApiSidecarOptions)
        .WithOtlpExporter()
        .WithHttpHealthCheck("/health")
        .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development");

builder.Build().Run();