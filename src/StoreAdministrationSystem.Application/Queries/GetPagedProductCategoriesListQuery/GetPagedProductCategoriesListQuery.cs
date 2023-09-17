using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.GetPagedProductCategoriesListQuery;

public sealed partial class GetPagedProductCategoriesListQuery : IQuery<
    GetPagedProductCategoriesListQuery.Results.SuccessResult,
    GetPagedProductCategoriesListQuery.Results.FailResults>
{
    public int Count { get; init; }
    public int Offset { get; init; }
    public string? Name { get; init; }
    public Guid? ProductCategoryId { get; init; }
}
