namespace StoreAdministrationSystem.Admin.Integration.Client.Models;

public sealed class CreateProductRequest
{
    /// <summary>
    /// Название продукта
    /// </summary>
    public string ProductName { get; init; } = null!;

    /// <summary>
    /// Описание продукта
    /// </summary>
    public string Description { get; init; } = null!;

    /// <summary>
    /// Цена за единицу товара
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Ссылка на изображение продукта
    /// </summary>
    public Uri ProductPicture { get; init; } = null!;

    /// <summary>
    /// Коллекция параметров продукта
    /// </summary>
    public Dictionary<string, string> Parameters { get; init; } = null!;

    /// <summary>
    /// ID категории товара
    /// </summary>
    public Guid ProductCategoryId { get; init; }
}
