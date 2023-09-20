namespace StoreAdministrationSystem.ReadModel.ProductCategories;

public sealed class ProductCategoryModelItem : IReadModelItem
{
    private ProductCategoryModelItem()
    {
    }

    public Guid ProductCategoryId { get; private set; }
    public string Name { get; private set; } = null!;
    public DateTimeOffset CreateDate { get; private set; }
    public DateTimeOffset UpdateDate { get; private set; }
}
