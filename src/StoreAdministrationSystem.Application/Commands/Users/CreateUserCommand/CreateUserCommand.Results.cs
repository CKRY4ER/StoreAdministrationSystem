using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.Users.CreateUserCommand;

public sealed partial class CreateUserCommand
{
    private static Results.SuccessResult Success()
        => new();

    private static Results.FailResult AlreadyExist()
        => new(ApplicationErrorCodes.USER_ALREADY_EXIST, "User already exists");

    public static class Results
    {
        public sealed class SuccessResult : ISuccessCommandResult
        {
        }

        public sealed class FailResult : IFailCommandResult
        {
            public FailResult(string code, string message)
            {
                Code = code;
                Message = message;
            }

            public string Code { get; init; } = null!;
            public string Message { get; init; } = null!;
        }
    }
}
