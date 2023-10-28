using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.Orders.CreateOrderCommand;

public sealed partial class CreateOrderCommand
{
    private static Results.SuccessResult Success()
        => new();

    private static Results.FailResult UserSchoppingCartIsEmpty()
        => new(ApplicationErrorCodes.USER_SCHOPPING_CART_EMPTY, "User schopping cart is empty");

    private static Results.FailResult UserNotFound()
        => new(ApplicationErrorCodes.USER_NOT_FOUND, "User not found");

    private static Results.FailResult NotEnoughtProduct()
        => new(ApplicationErrorCodes.NOT_ENOUGHT_PRODUCT, "There is not enough product to form an order");

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
