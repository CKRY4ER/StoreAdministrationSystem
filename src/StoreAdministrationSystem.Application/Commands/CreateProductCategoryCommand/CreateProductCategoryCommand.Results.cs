using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.CreateProductCategoryProductCommand;

public sealed partial class CreateProductCategoryCommand
{
    private static Results.SuccessResult Success() => new();

    private static Results.FailResult AlreadyExists()
        => new(ApplicationErrorCodes.PRODUCT_CATEGORY_ALREADY_EXISTS, "Product category already exists");

    private static Results.FailResult InternalError()
        => new(ApplicationErrorCodes.INTERNAL_ERROR, "Internal error");

    public static class Results
    {
        public class SuccessResult : ISuccessCommandResult
        {
        }

        public sealed class FailResult : IFailCommandResult
        {
            public FailResult(string code, string message)
            {
                Message = message;
                Code = code;
            }

            public string Message { get; init; } = null!;
            public string Code { get; init; } = null!;
        }
    }
}
