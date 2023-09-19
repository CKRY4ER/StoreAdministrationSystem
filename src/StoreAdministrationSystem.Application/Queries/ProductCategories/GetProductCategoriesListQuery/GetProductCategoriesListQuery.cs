using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.ProductCategories;

public sealed partial class GetProductCategoriesListQuery : IQuery<
    GetProductCategoriesListQuery.Results.SuccessResult,
    GetProductCategoriesListQuery.Results.FailResult>
{
}
