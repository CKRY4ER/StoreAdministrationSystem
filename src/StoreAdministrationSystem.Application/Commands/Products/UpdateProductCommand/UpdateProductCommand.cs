using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.Products;

public sealed partial class UpdateProductCommand : ICommand<
    UpdateProductCommand.Results.SuccessResult,
    UpdateProductCommand.Results.FailResult>
{
    public Guid ProductId { get; init; }
    public string ProductName { get; init; } = null!;
    public string Description { get; init; } = null!;
    public decimal Price { get; init; }
    public Uri ProductPicture { get; init; } = null!;
    public Dictionary<string, string> Parameters { get; init; } = null!;
    public Guid ProductCategoryId { get; init; }
}
