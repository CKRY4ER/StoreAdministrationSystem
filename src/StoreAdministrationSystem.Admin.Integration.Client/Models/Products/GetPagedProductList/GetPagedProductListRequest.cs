namespace StoreAdministrationSystem.Admin.Integration.Client.Models;

public sealed class GetPagedProductListRequest : PageRequest
{
    /// <summary>
    /// Название продукта
    /// </summary>
    public string? ProductName { get; init; } = null;

    /// <summary>
    /// ID продукта
    /// </summary>
    public Guid? ProdcutId { get; init; } = null;

    /// <summary>
    /// ID категории
    /// </summary>
    public Guid? ProductCategoryId { get; init; } = null;
}
