namespace StoreAdministrationSystem.Integration.Client.Models;

public sealed class GetOrderByIdResponse
{
    public Guid OrderId { get; init; }
    public Guid UserId { get; init; }
    public string OrderStatus { get; init; } = null!;
    public IEnumerable<OrderPosition> OrderPositions { get; init; } = null!;
    public decimal TotalPrice { get; init; }
    public DateTimeOffset CreateDate { get; init; }
    public DateTimeOffset UpdateDate { get; init; }
}

public sealed class OrderPosition
{
    public Guid ProductId { get; init; }
    public string ProductName { get; init; } = null!;
    public int Count { get; init; }
    public decimal PositionPrice { get; init; }
}
