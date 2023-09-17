using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Commands.UpdateProductCategoryCommand;

public sealed partial class UpdateProductCategoryCommand
{
    private static Results.SuccessResult Success()
        => new();

    private static Results.Failresult NotFound()
        => new(ApplicationErrorCodes.PRODUCT_CATEGORY_NOT_FOUND, "Product category not found");

    private static Results.Failresult InternalError()
        => new(ApplicationErrorCodes.INTERNAL_ERROR, "Intenal error");

    public static class Results
    {
        public sealed class SuccessResult : ISuccessCommandResult
        {
        }

        public sealed class Failresult : IFailCommandResult
        {
            public Failresult(string code, string message)
            {
                Message = message;
                Code = code;
            }

            public string Message { get; init; } = null!;
            public string Code { get; init; } = null!;
        }
    }
}
