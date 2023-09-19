using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.Products;

public sealed partial class CreateProductCommand
{
    private static Results.SuccessResult Success()
        => new();

    private static Results.FailResult AlreadyExists()
        => new(ApplicationErrorCodes.PRODUCT_ALREADY_EXIST, "Product already exists");

    private static Results.FailResult ProductCategoryNotFound()
        => new(ApplicationErrorCodes.PRODUCT_CATEGORY_NOT_FOUND, "Product category not found");

    private static Results.FailResult InternalError()
        => new(ApplicationErrorCodes.INTERNAL_ERROR, "Internal error");

    public static class Results
    {
        public sealed class SuccessResult : ISuccessCommandResult
        {
            public SuccessResult() 
            {
            }
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
