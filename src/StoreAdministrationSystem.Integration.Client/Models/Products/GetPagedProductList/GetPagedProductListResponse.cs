namespace StoreAdministrationSystem.Integration.Client.Models;

public sealed class GetPagedProductListResponse
{
    /// <summary>
    /// ID продукта
    /// </summary>
    public Guid ProductId { get; init; }

    /// <summary>
    /// Название продукта
    /// </summary>
    public string ProductName { get; init; } = null!;

    /// <summary>
    /// Цена за единицу товара
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Кол-во товара на складе
    /// </summary>
    public int Count { get; init; }

    /// <summary>
    /// ID категории
    /// </summary>
    public Guid ProductCategoryId { get; init; }

    /// <summary>
    /// Название категории
    /// </summary>
    public string ProductCategoryName { get; init; } = null!;

    /// <summary>
    /// Дата создания продукта
    /// </summary>
    public DateTimeOffset CreateDate { get; init; }

    /// <summary>
    /// Дата обновления продукта
    /// </summary>
    public DateTimeOffset UpdateDate { get; init; }
}
