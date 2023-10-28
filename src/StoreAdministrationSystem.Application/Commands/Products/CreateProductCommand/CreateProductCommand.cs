using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.Products.CreateProductCommand;

public sealed partial class CreateProductCommand : ICommand<
    CreateProductCommand.Results.SuccessResult,
    CreateProductCommand.Results.FailResult>
{
    public string ProductName { get; init; } = null!;
    public string Description { get; init; } = null!;
    public decimal Price { get; init; }
    public Uri ProductPicture { get; init; } = null!;
    public Dictionary<string, string> Parameters { get; init; } = null!;
    public Guid ProductCategoryId { get; init; }
}
