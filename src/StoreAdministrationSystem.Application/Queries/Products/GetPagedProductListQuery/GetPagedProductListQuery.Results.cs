using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Products;

public sealed partial class GetPagedProductListQuery
{
    private static Results.SuccessResult Success(Page<Results.ProductReference> products)
        => new(products);

    public static class Results
    {
        public class SuccessResult : ISuccessQueryResult
        {
            public SuccessResult(Page<ProductReference> products)
            {
                Products = products;
            }

            public Page<ProductReference> Products { get; init; } = null!;
        }

        public class FailResult : IFailQueryResult
        {
            public FailResult(string code, string message)
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
            public DateTimeOffset CreateDate { get; init; }
            public DateTimeOffset UpdateDate { get; init; }
        }
    }
}
