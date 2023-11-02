namespace StoreAdministrationSystem.Admin.Integration.Client.Models;

public sealed class CreateAdminUserRequest
{
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string Login { get; init; } = null!;
}
