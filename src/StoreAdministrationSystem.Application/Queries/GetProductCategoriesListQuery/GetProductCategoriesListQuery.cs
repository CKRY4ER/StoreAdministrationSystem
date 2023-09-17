using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.GetProductCategoriesListQuery;

public sealed partial class GetProductCategoriesListQuery : IQuery<
    GetProductCategoriesListQuery.Results.SuccessResult,
    GetProductCategoriesListQuery.Results.FailResult>
{
}
