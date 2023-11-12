using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace StoreAdministrationSystem.Admin.Integration.Client;

public static class ServiceCollectionExtensions
{
    public static void AddStoreAdministrationServiceRefitClient(this IServiceCollection collection, HttpStoreAdministrationServiceAdminClientOptions options)
    {
        collection.AddRefitClient<IStoreAdministrationServiceAdminClient>().ConfigureHttpClient((client) =>
        {
            client.BaseAddress = new Uri(options.Address);
        });
    }
}
