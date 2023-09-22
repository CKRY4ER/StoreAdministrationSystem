using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.Orders;

public sealed partial class CreateOrderCommand : ICommand<
    CreateOrderCommand.Results.SuccessResult,
    CreateOrderCommand.Results.FailResult>
{
    public Guid UserId { get; init; }
}
