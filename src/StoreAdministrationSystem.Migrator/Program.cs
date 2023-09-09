using Serilog;
using StoreAdministrationSystem.DataAccess.PostgresSql;
using StoreAdministrationSystem.DataAccess.PostgresSql.Migrator;

var host = Host.CreateDefaultBuilder(args)
    .UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration))
    .ConfigureServices((hostContext, services) =>
    {
        var connectionString = hostContext.Configuration.GetConnectionString("postgres")!;
        services.AddPostgresSqlShemaMigrator(connectionString);
    }).Build();

using var scope = host.Services.CreateScope();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<IStoreAdministrationSystemShemaMigrator>>();
var storeAdministrationSystemShecmaMigrator = scope.ServiceProvider.GetRequiredService<IStoreAdministrationSystemShemaMigrator>();

logger.LogInformation("Migrator - started");

try
{
    await storeAdministrationSystemShecmaMigrator.MigrateAsync();
}
catch(Exception ex)
{
    logger.LogError(ex, $"Error occured");
    Environment.ExitCode = -1;
}

logger.LogInformation("Migrator - stopped");
