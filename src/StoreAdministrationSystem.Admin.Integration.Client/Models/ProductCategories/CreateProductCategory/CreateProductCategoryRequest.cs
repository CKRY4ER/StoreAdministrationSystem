namespace StoreAdministrationSystem.Admin.Integration.Client.Models;

public sealed class CreateProductCategoryRequest
{
    /// <summary>
    /// Название категории
    /// </summary>
    public string Name { get; init; } = null!;
}
