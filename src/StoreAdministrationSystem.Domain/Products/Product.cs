namespace StoreAdministrationSystem.Domain.Products;

public sealed class Product : Aggregate
{
    private Product() { }

    public Product(Guid aggregateId, string productName,
        string description, decimal price,
        int count, Uri productPictureUri,
        IDictionary<string, string> parameters, Guid categoryId)
            : base(Guid.NewGuid())
    {
        ProductName = productName;
        Description = description;
        Price = price;
        Count = count;
        ProductPictureUri = productPictureUri;
        Parameters = parameters;
        CategoryId = categoryId;
        CreateDate = UpdateDate = DateTime.UtcNow;
    }

    public string ProductName { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public int Count { get; private set; }
    public Uri ProductPictureUri { get; private set; } = null!;
    public IDictionary<string, string> Parameters { get; private set; } = null!;
    public Guid CategoryId { get; private set; }
    public DateTimeOffset CreateDate { get; private set; }
    public DateTimeOffset UpdateDate { get; private set; }
}
