using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreAdministrationSystem.DataAccess.PostgresSql.Migrator;
using StoreAdministrationSystem.DataAccess.PostgresSql.Migrator.Context;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Orders;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Orders.Context;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.ProductCategories;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.ProductCategories.Context;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Products;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Products.Context;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Users;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Users.Context;
using StoreAdministrationSystem.DataAccess.Repositories.Orders;
using StoreAdministrationSystem.DataAccess.Repositories.ProductCategories;
using StoreAdministrationSystem.DataAccess.Repositories.Products;
using StoreAdministrationSystem.DataAccess.Repositories.Users;

namespace StoreAdministrationSystem.DataAccess.PostgresSql;

public static class ServiceCollectionExtensions
{
    public static void AddPostgresSqlShemaMigrator(this IServiceCollection collectin, string connectionString)
    {
        collectin.AddDbContext<MigratorDbContext>(builder =>
            builder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());
        collectin.AddScoped<IStoreAdministrationSystemShemaMigrator, StoreAdministrationSystemShemaMigrator>();
    }

    public static void AddPostgresSqlRepositories(this IServiceCollection collection, string connectionString)
    {
        collection.AddPostgresSqlRepository<IOrderRepository, OrderRepository, OrderDbContext>(connectionString);
        collection.AddPostgresSqlRepository<IUserRepository, UserRepository, UserDbContext>(connectionString);
        collection.AddPostgresSqlRepository<IProductRepository, ProductRepository, ProductDbContext>(connectionString);
        collection.AddPostgresSqlRepository<IProductCategoryRepository, ProductCategoryRepository ,ProductCategoriesDbContext>(connectionString);
    }

    private static void AddPostgresSqlRepository<TRepository, TRepositoryImplementation, TDbContext> (
        this IServiceCollection collection, string connectionString)
        where TRepository : class
        where TRepositoryImplementation : class, TRepository
        where TDbContext : DbContext
    {
        collection.AddDbContextFactory<TDbContext>(builder =>
            builder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

        collection.AddScoped<TRepository, TRepositoryImplementation>();
    }
}
