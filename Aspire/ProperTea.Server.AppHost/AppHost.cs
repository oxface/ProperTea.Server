using CommunityToolkit.Aspire.Hosting.Dapr;

var builder = DistributedApplication.CreateBuilder(args);

var azureSql = builder.AddAzureSqlServer("propertea-sql")
    .RunAsContainer(e =>
    {
        e.WithDataVolume("propertea-sql-data");
        e.WithLifetime(ContainerLifetime.Persistent);
    });
var companyDb = azureSql.AddDatabase("propertea-company-db");
var migrations = builder.AddProject<Projects.ProperTea_Company_MigrationService>("migrations")
    .WithReference(companyDb)
    .WaitFor(companyDb);

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
        .WithReference(companyDb)
        .WithReference(migrations)
        .WaitForCompletion(migrations)
        .WaitFor(companyDb)
        .WithDaprSidecar(companyApiSidecarOptions)
        .WithOtlpExporter()
        .WithHttpHealthCheck("/health")
        .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development");

builder.Build().Run();