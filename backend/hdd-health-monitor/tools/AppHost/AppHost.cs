using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var mariaDb = builder
    .AddMySql("mariadb")
    .WithImage("mariadb", "11")
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

var db = mariaDb
    .AddDatabase("AppDb", "app-db");

var migrationService = builder
    .AddProject<MigrationService>("migrations")
    .WithReference(db)
    .WaitFor(mariaDb);

var api = builder
    .AddProject<WebApi>("api")
    .WithExternalHttpEndpoints()
    .WithReference(db)
    .WaitForCompletion(migrationService);

builder.Build().Run();