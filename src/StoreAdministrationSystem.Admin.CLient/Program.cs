using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using StoreAdministrationSystem.Admin.Client;
using StoreAdministrationSystem.Admin.Client.Services;
using StoreAdministrationSystem.Admin.Integration.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddStoreAdministrationServiceRefitClient(builder.Configuration.GetSection("Integrations:StoreAdministrationSystemService")
    .Get<HttpStoreAdministrationServiceAdminClientOptions>());
builder.Services.AddScoped<IStoreAdministrationSystemService, StoreAdministrationSystemService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
