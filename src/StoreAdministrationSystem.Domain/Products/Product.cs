using StoreAdministrationSystem.Domain.ProductCategories;

namespace StoreAdministrationSystem.Domain.Products;

public sealed class Product : Aggregate
{
    private Product() { }

    public Product(string productName,
        string description, decimal price, Uri productPictureUri,
        Dictionary<string, string> parameters, ProductCategory productCategory)
            : base(Guid.NewGuid())
    {
        ProductName = productName;
        Description = description;
        Price = price;
        ProductPictureUrl = productPictureUri;
        Parameters = parameters;
        Count = 0;
        ProductCategory = productCategory;
        CreateDate = UpdateDate = DateTime.UtcNow;
    }

    public string ProductName { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public int Count { get; private set; }
    public Uri ProductPictureUrl { get; private set; } = null!;
    public Dictionary<string, string> Parameters { get; private set; } = null!;
    public ProductCategory ProductCategory { get; private set; } = null!;
    public DateTimeOffset CreateDate { get; private set; }
    public DateTimeOffset UpdateDate { get; private set; }

    public void UpdateInformation(string productName,
        string description, decimal price, Uri productPictureUri,
        Dictionary<string, string> parameters, ProductCategory productCategory)
    {
        ProductName = productName;
        Description = description;
        Price = price;
        ProductPictureUrl = productPictureUri;
        Parameters = parameters;
        ProductCategory = productCategory;
        UpdateDate = DateTime.UtcNow;
    }
}
