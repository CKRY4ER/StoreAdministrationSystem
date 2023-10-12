namespace StoreAdministrationSystem.Admin.Api;

public sealed class CorsOptions
{
    public string Name { get; set; } = "AnyOrigins";
    public string[] Origins { get; set; } = Array.Empty<string>();
}
