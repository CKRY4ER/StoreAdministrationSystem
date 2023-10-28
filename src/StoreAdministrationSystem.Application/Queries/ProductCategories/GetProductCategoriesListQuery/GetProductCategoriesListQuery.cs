using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.ProductCategories.GetProductCategoriesListQuery;

public sealed partial class GetProductCategoriesListQuery : IQuery<
    GetProductCategoriesListQuery.Results.SuccessResult,
    GetProductCategoriesListQuery.Results.FailResult>
{
}
