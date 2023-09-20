using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Products;

public sealed partial class GetPagedProductListQuery : IQuery<
    GetPagedProductListQuery.Results.SuccessResult,
    GetPagedProductListQuery.Results.FailResult>
{
    public int Count { get; init; }
    public int Offset { get; init; }
    public string? ProductName { get; init; }
    public Guid? ProductId { get; init; }
    public Guid? ProductCategoryId { get; init; }
}
