using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.ProductCategories;

public sealed partial class UpdateProductCategoryCommand : ICommand<
    UpdateProductCategoryCommand.Results.SuccessResult,
    UpdateProductCategoryCommand.Results.FailResult>
{
    public Guid ProductCategoryId { get; init; } 
    public string Name { get; init; } = null!;
}
