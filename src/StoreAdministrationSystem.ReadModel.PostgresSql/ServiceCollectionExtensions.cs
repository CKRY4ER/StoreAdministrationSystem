using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreAdministrationSystem.ReadModel.PostgresSql.Context;

namespace StoreAdministrationSystem.ReadModel.PostgresSql;

public static class ServiceCollectionExtensions
{
    public static void AddPostgresSqlReadModel(this IServiceCollection collection, string connectiontring)
    {
        collection.AddDbContext<IReadModelDbContext, ReadModelDbContext>(builder =>
            builder.UseNpgsql(connectiontring).UseSnakeCaseNamingConvention());
        collection.AddScoped<IReadModelQueryExecutor, IReadModelQueryExecutor>();
        collection.AddScoped(typeof(IReadModelQueryProvider<>), typeof(ReadModelQueryProvider<>));
    }
}
