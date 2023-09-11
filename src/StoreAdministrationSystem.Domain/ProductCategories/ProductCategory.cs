using StoreAdministrationSystem.Domain.Products;

namespace StoreAdministrationSystem.Domain.ProductCategories;

public sealed class ProductCategory : Aggregate
{
    private ProductCategory() { }

    public ProductCategory(string name)
        : base(Guid.NewGuid())
    {
        Name = name;
        CreateDate = UpdateDate = DateTimeOffset.UtcNow;
    }

    public string Name { get; private set; } = null!;
    public DateTimeOffset CreateDate { get; private set; }
    public DateTimeOffset UpdateDate { get; private set; }
}
