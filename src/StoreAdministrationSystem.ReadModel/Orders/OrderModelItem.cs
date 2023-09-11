namespace StoreAdministrationSystem.ReadModel.Orders;

public sealed class OrderModelItem : IReadModelItem
{
    private OrderModelItem()
    {
    }

    public Guid OrderId { get; private set; }
    public Guid UserId { get; private set; }
    public decimal TotalPrice { get; private set; }
    public string OrderStatus { get; private set; } = null!;
    public DateTimeOffset CreateDate { get; private set; } 
    public DateTimeOffset UpdateDate { get; private set; }
}
