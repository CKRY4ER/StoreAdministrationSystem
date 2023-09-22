using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Orders;

public sealed partial class GetOrderByIdQuery
{
    private static Results.SuccessResult Success(Results.OrderReference order)
        => new(order);

    private static Results.FailResult NotFound()
        => new(ApplicationErrorCodes.ORDER_NOT_FOUND, "Order not found");

    public static class Results
    {
        public sealed class SuccessResult : ISuccessQueryResult
        {
            public SuccessResult(OrderReference order)
            {
                Order = order;
            }

            public OrderReference Order { get; init; } = null!;
        }

        public sealed class FailResult : IFailQueryResult
        {
            public FailResult(string code, string message)
            {
                Code = code;
                Message = message;
            }

            public string Code { get; init; } = null!;
            public string Message { get; init; } = null!;
        }

        public sealed class OrderReference
        {
            public Guid OrderId { get; init; }
            public Guid UserId { get; init; }
            public string OrderStatus { get; init; } = null!;
            public IEnumerable<OrderPositionReference> OrderPositions { get; init; } = null!;
            public decimal TotalPrice { get; init; }
            public DateTimeOffset CreateDate { get; init; }
            public DateTimeOffset UpdateDate { get; init; }
        }

        public sealed class OrderPositionReference
        {
            public Guid ProductId { get; init; }
            public string ProductName { get; init; } = null!;
            public int Count { get; init; }
            public decimal PositionPrice { get; init; }
        }
    } 
}
