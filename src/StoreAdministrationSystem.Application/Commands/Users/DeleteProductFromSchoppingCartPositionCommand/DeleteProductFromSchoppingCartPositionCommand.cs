using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.Users;

public sealed partial class DeleteProductFromSchoppingCartPositionCommand : ICommand<
    DeleteProductFromSchoppingCartPositionCommand.Results.SuccessResult,
    DeleteProductFromSchoppingCartPositionCommand.Results.FailResults>
{
    public Guid UserId { get; init; }
    public Guid ProductId { get; init; }
    public int ProductCount { get; init; }
}
