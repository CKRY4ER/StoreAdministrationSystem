using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.Users.AddProductInUserSchoppingCartCommand;

public sealed partial class AddProductInUserSchoppingCartCommand : ICommand<
    AddProductInUserSchoppingCartCommand.Results.SuccessResult,
    AddProductInUserSchoppingCartCommand.Results.FailResult>
{
    public Guid UserId { get; init; }
    public Guid ProductId { get; init; }
    public int ProductCount { get; init; }
}
