using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreAdministrationSystem.DataAccess.PostgresSql.Migrator;
using StoreAdministrationSystem.DataAccess.PostgresSql.Migrator.Context;

namespace StoreAdministrationSystem.DataAccess.PostgresSql;

public static class ServiceCollectionExtensions
{
    public static void AddPostgresSqlShemaMigrator(this IServiceCollection collectin, string connectionString)
    {
        collectin.AddDbContext<MigratorDbContext>(builder =>
            builder.UseNpgsql(connectionString));
        collectin.AddScoped<IStoreAdministrationSystemShemaMigrator, StoreAdministrationSystemShemaMigrator>();
    }
}
