using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Orders.GetOrderByIdQuery;

public sealed partial class GetOrderByIdQuery : IQuery<
    GetOrderByIdQuery.Results.SuccessResult,
    GetOrderByIdQuery.Results.FailResult>
{
    public Guid OrderId { get; init; }
}
