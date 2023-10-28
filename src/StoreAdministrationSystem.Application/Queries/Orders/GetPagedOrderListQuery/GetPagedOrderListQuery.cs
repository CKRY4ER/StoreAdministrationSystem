using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Orders.GetPagedOrderListQuery;

public sealed partial class GetPagedOrderListQuery : IQuery<
    GetPagedOrderListQuery.Results.SuccessResult,
    GetPagedOrderListQuery.Results.FailResult>
{
    public int Count { get; init; }
    public int Offset { get; init; }
    public Guid? UserId { get; init; } = null;
    public Guid? OrderId { get; init; } = null;
}
