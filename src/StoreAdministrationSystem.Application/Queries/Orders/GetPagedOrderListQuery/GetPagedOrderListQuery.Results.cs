using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Orders.GetPagedOrderListQuery;

public sealed partial class GetPagedOrderListQuery
{
    private static Results.SuccessResult Success(Page<OrderReference> orders)
        => new(orders);

    public static class Results
    {
        public sealed class SuccessResult : ISuccessQueryResult
        {
            public SuccessResult(Page<OrderReference> orders)
            {
                Orders = orders;
            }

            public Page<OrderReference> Orders { get; init; } = null!;
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
    }

    public sealed class OrderReference
    {
        public Guid OrderId { get; init; }
        public Guid UserId { get; init; }
        public decimal TotalPrice { get; init; }
        public string Status { get; init; } = null!;
        public DateTimeOffset CreateDate { get; init; }
        public DateTimeOffset UpdateDate { get; init; }
    }
}
