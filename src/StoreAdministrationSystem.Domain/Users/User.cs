namespace StoreAdministrationSystem.Domain.Users;

public sealed class User : Aggregate
{
    private ICollection<UserDocument> _documents = new List<UserDocument>();
    
    private User() { }

    public User(string email, string login,
        string password, bool isAdmin)
        : base(Guid.NewGuid())
    {
        Email = email;
        Login = login;
        Password = password;
        IsAdmin = isAdmin;
    }

    public string Email { get; private set; } = null!;
    public string Login { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public bool IsAdmin { get; private set; }
    public IEnumerable<UserDocument> Documents => _documents;
    public DateTimeOffset CreateDate { get; private set; }
    public DateTimeOffset UpdateDate { get; private set; }
}
