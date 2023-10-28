using StoreAdministrationSystem.Application.Framework;
using System.Windows.Input;

namespace StoreAdministrationSystem.Application.Commands.Users.CreateUserCommand;

public sealed partial class CreateUserCommand : ICommand<
    CreateUserCommand.Results.SuccessResult,
    CreateUserCommand.Results.FailResult>
{
    public string Login { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string Email { get; init; } = null!;
    public bool IsAdmin { get; init; }
}
