using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.ProductCategories;

public sealed partial class CreateProductCategoryCommand : ICommand<
    CreateProductCategoryCommand.Results.SuccessResult,
    CreateProductCategoryCommand.Results.FailResult>
{
    public string ProductCategoryName { get; init; } = null!;
}
