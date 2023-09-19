using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Products;

public sealed partial class GetProductListQuery
{
    private static Results.SuccessResult Success(IEnumerable<Results.ProductReference> products)
        => new(products);

    private static Results.FailResults NotFound()
        => new(ApplicationErrorCodes.PRODUCT_NOT_FOUND, "Products not found");

    private static Results.FailResults InternalError()
        => new(ApplicationErrorCodes.INTERNAL_ERROR, "Internal error");

    public static class Results
    {
        public class SuccessResult : ISuccessQueryResult
        {
            public SuccessResult(IEnumerable<ProductReference> products)
                => Products = products;

            IEnumerable<ProductReference> Products { get; init; } = null!;
        }

        public class FailResults : IFailQueryResult
        {
            public FailResults(string code, string message)
            {
                Code = code;
                Message = message;
            }

            public string Code { get; init; } = null!;
            public string Message { get; init; } = null!;
        }

        public sealed class ProductReference
        {
            public Guid ProductId { get; init; }
            public string ProductName { get; init; } = null!;
            public decimal Price { get; init; }
            public int Count { get; init; }
            public Guid ProductCategoryId { get; init; }
            public string ProductCategoryName { get; init; } = null!;
        }
    }
}
