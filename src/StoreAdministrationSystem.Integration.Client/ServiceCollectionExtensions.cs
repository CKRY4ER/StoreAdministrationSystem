using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace StoreAdministrationSystem.Integration.Client;

public static class ServiceCollectionExtensions
{
    public static void AddStorerAdministrationServiceRefitClient(this IServiceCollection collection, HttpStoreAdministrationServiceClientOptions options)
    {
        collection.AddRefitClient<IStoreAdministrationServiceClient>().ConfigureHttpClient((client) =>
        {
            client.BaseAddress = new Uri(options.Adress);
        });
    }
}
