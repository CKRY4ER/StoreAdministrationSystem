namespace StoreAdministrationSystem.Integration.Client.Models;

public sealed class GetPagedProductCategoriesListRequest : PageRequest
{
    /// <summary>
    /// Название категории
    /// </summary>
    public string? Name { get; init; } = null;

    /// <summary>
    /// ID категории
    /// </summary>
    public Guid? ProductCategoryId { get; init; } = null;
}
