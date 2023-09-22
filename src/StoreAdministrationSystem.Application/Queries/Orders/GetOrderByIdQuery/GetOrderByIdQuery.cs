using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Orders;

public sealed partial class GetOrderByIdQuery : IQuery<
    GetOrderByIdQuery.Results.SuccessResult,
    GetOrderByIdQuery.Results.FailResult>
{
    public Guid OrderId { get; init; }
}
