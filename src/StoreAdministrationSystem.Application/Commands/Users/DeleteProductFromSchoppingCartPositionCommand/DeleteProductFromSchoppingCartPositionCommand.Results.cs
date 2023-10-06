using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.Users;

public sealed partial class DeleteProductFromSchoppingCartPositionCommand
{
    private static Results.SuccessResult Success()
        => new();

    private static Results.FailResults UserNotFound()
        => new(ApplicationErrorCodes.USER_NOT_FOUND, "User not found");

    private static Results.FailResults ProductNotFound()
        => new(ApplicationErrorCodes.PRODUCT_NOT_FOUND, "Product not found");

    private static Results.FailResults SchoppingCartPositionNotFound()
        => new(ApplicationErrorCodes.USER_SCHOPPING_CART_POSITION_NOT_FOUND, "User schopping cart position not found");

    public static class Results
    {
        public sealed class SuccessResult : ISuccessCommandResult
        {
        }

        public sealed class FailResults : IFailCommandResult
        {
            public FailResults(string code, string message)
            {
                Code = code;
                Message = message;
            }

            public string Code { get; init; } = null!;
            public string Message { get; init; } = null!;
        }
    }
}
