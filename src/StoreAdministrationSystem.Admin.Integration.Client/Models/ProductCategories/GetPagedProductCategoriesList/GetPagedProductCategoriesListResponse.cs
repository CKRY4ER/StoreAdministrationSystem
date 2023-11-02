namespace StoreAdministrationSystem.Admin.Integration.Client.Models;

public sealed class GetPagedProductCategoriesListResponse
{
    /// <summary>
    /// ID категории
    /// </summary>
    public Guid ProductCategoryId { get; init; }

    /// <summary>
    /// Название категории
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    /// Дата создания категории
    /// </summary>
    public DateTimeOffset CreateDate { get; init; }

    /// <summary>
    /// Дата обновления категории
    /// </summary>
    public DateTimeOffset UpdateDate { get; init; }
}
