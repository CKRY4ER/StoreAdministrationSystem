using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.Users.AddProductInUserSchoppingCartCommand;

public sealed partial class AddProductInUserSchoppingCartCommand
{
    private static Results.SuccessResult Success()
        => new();

    private static Results.FailResult UserNotFound()
        => new(ApplicationErrorCodes.USER_NOT_FOUND, "User not found");

    private static Results.FailResult ProductNotFound()
        => new(ApplicationErrorCodes.PRODUCT_NOT_FOUND, "Product not found");

    private static Results.FailResult NotEnoughtProduct()
        => new(ApplicationErrorCodes.NOT_ENOUGHT_PRODUCT, "It is not possible to add more product than is in stock");

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
