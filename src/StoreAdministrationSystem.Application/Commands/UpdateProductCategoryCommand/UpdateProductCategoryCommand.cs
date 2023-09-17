using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.UpdateProductCategoryCommand;

public sealed partial class UpdateProductCategoryCommand : ICommand<
    UpdateProductCategoryCommand.Results.SuccessResult,
    UpdateProductCategoryCommand.Results.Failresult>
{
    public Guid ProductCategoryId { get; init; } 
    public string Name { get; init; } = null!;
}
