namespace StoreAdministrationSystem.ReadModel.Products;

public sealed class ProductModelItem : IReadModelItem
{
    private ProductModelItem()
    { 
    }

    public Guid ProductId { get; private set; }
    public Guid ProductCategoryId { get; private set; }
    public string ProductName { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public int Count { get; private set; }
    public Uri ProductPictureUrl { get; private set; } = null!;
    public IDictionary<string, string> Parameters { get; private set; } = null!;
    public DateTimeOffset CreateDate { get; private set; }
    public DateTimeOffset UpdateDate { get; private set; }
}
