namespace StoreAdministrationSystem.Admin.Integration.Client.Models;

public sealed class GetPagedUserListRequest : PageRequest
{
    /// <summary>
    /// ID пользователя
    /// </summary>
    public Guid? UserId { get; init; } = null;
}
