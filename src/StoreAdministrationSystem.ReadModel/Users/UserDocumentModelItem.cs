namespace StoreAdministrationSystem.ReadModel.Users;

public sealed class UserDocumentModelItem : IReadModelItem
{
    private UserDocumentModelItem()
    { 
    }

    public Guid UserId { get; private set; }
    public Guid DocumentId { get; private set; }
    public string DocumentType { get; private set; } = null!;
}
