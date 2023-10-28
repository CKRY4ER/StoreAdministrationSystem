using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.ProductCategories.GetProductCategoriesListQuery;

public sealed partial class GetProductCategoriesListQuery
{
    private static Results.SuccessResult Success(IEnumerable<ProductCategoryReference> productCategories)
        => new(productCategories);

    private static Results.FailResult NotFound()
        => new(ApplicationErrorCodes.PRODUCT_CATEGORY_NOT_FOUND, "Product categories not found");

    private static Results.FailResult InternalError()
        => new(ApplicationErrorCodes.INTERNAL_ERROR, "Internal error");

    public static class Results
    {
        public sealed class SuccessResult : ISuccessQueryResult
        {
            public SuccessResult(IEnumerable<ProductCategoryReference> productCategories)
                => ProductCategories = productCategories;

            public IEnumerable<ProductCategoryReference> ProductCategories { get; init; } = null!;
        }

        public sealed class FailResult : IFailQueryResult
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

    public sealed class ProductCategoryReference
    {
        public Guid ProductCategoryId { get; init; }
        public string Name { get; init; } = null!;
    }
}
