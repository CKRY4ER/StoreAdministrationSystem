namespace StoreAdministrationSystem.ReadModel.Users;

public sealed class UserSchoppingCartPositionModelItem : IReadModelItem
{
    private UserSchoppingCartPositionModelItem()
    {
    }

    public Guid UserId { get; private set; }
    public Guid ProductId { get; private set; }
    public int ProductCount { get; private set; }
}
