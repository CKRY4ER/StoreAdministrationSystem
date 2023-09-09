using StoreAdministrationSystem.Domain.ProductCategories;

namespace StoreAdministrationSystem.Domain.Products;

public sealed class Product : Aggregate
{
    private Product() { }

    public Product(Guid aggregateId, string productName,
        string description, decimal price,
        int count, Uri productPictureUri,
        IDictionary<string, string> parameters, ProductCategory productCategory)
            : base(Guid.NewGuid())
    {
        ProductName = productName;
        Description = description;
        Price = price;
        Count = count;
        ProductPictureUrl = productPictureUri;
        Parameters = parameters;
        ProductCategory = productCategory;
        CreateDate = UpdateDate = DateTime.UtcNow;
    }

    public string ProductName { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public int Count { get; private set; }
    public Uri ProductPictureUrl { get; private set; } = null!;
    public IDictionary<string, string> Parameters { get; private set; } = null!;
    public ProductCategory ProductCategory { get; private set; } = null!;
    public DateTimeOffset CreateDate { get; private set; }
    public DateTimeOffset UpdateDate { get; private set; }
}
