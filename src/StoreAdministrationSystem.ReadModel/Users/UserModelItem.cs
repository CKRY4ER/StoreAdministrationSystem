namespace StoreAdministrationSystem.ReadModel.Users;

public sealed class UserModelItem : IReadModelItem
{
    private UserModelItem()
    { 
    }

    public Guid UserId { get; private set; }
    public string Email { get; private set; } = null!;
    public string Login { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public bool isAdmin { get; private set; }
    public DateTimeOffset CreateDate { get; private set; }
    public DateTimeOffset UpdateDate { get; private set; }
}
