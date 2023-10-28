﻿using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Products.GetProductListQuery;

public sealed partial class GetProductListQuery : IQuery<
    GetProductListQuery.Results.SuccessResult,
    GetProductListQuery.Results.FailResults>
{
    public Guid ProductCategoryid { get; init; }
}
