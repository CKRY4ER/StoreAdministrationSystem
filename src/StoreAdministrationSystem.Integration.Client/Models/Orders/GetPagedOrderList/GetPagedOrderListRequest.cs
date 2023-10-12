namespace StoreAdministrationSystem.Integration.Client.Models;

public sealed class GetPagedOrderListRequest : PageRequest
{
    public Guid? OrderId { get; init; } = null;
    public Guid? UserId { get; init; } = null;
}
