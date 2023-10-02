namespace StoreAdministrationSystem.Domain.Users;

public sealed class UserDocument
{
    private UserDocument() { }

    public UserDocument(Guid documentId)
        => DocumentId = documentId;

    public Guid DocumentId { get; private set; }
    public string DocumentType { get; init; } = null!;
}
