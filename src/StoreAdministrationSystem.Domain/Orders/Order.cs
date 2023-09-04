namespace StoreAdministrationSystem.Domain.Orders;

public sealed class Order : Aggregate
{
    private Order() { }

    public Order(Guid userId, decimal totalPrice,
        ICollection<OrderPosition> orderPosition)
        : base(Guid.NewGuid())
    {
        UserId = userId;
        TotalPrice = totalPrice;
        OrderPosition = orderPosition;
        CreateDate = UpdateDate = DateTimeOffset.UtcNow;
    }

    public Guid UserId { get; private set; }
    public decimal TotalPrice { get; private set; }
    public IEnumerable<OrderPosition> OrderPosition { get; private set; } = null!;
    public DateTimeOffset CreateDate { get; private set; }
    public DateTimeOffset UpdateDate { get; private set; }
}
