using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace StoreAdministrationSystem.Application.Framework;

public static class ServiceCollectionExtensions
{
    public static void AddFramework(this IServiceCollection collection)
    {
        collection.AddMediatR(Assembly.GetExecutingAssembly());

        collection.AddScoped<ICommandExecutor, CommandExecutor>();
        collection.AddScoped<IQueryExecutor, QueryExecutor>();
    }
}
