using StoreAdministrationSystem.Application.Framework;
using static StoreAdministrationSystem.Application.Queries.GetPagedProductCategoriesListQuery.GetPagedProductCategoriesListQuery.Results;

namespace StoreAdministrationSystem.Application.Queries.GetPagedProductCategoriesListQuery;

public sealed partial class GetPagedProductCategoriesListQuery
{
    private static Results.SuccessResult Success(Page<ProductCatogoryReference> productCategories)
        => new(productCategories);

    public static class Results
    {
        public sealed class SuccessResult : ISuccessQueryResult
        {
            public SuccessResult(Page<ProductCatogoryReference> productCategories)
            {
                ProductCategories = productCategories;
            }

            public Page<ProductCatogoryReference> ProductCategories { get; init; } = null!;
        }

        public sealed class FailResults : IFailQueryResult
        {
            public FailResults(string code, string message)
            {
                Message = message;
                Code = code;
            }

            public string Message { get; init; } = null!;
            public string Code { get; init; } = null!;
        }

        public sealed class ProductCatogoryReference
        {
            public Guid ProductCategoryId { get; init; }
            public string Name { get; init; } = null!;
            public DateTimeOffset CreateDate { get; init; }
            public DateTimeOffset UpdateDate { get; init; }
        }
    }
}
