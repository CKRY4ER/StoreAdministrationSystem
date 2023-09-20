namespace StoreAdministrationSystem.ReadModel.Orders;

public sealed class OrderPositionModelItem : IReadModelItem
{
    private OrderPositionModelItem()
    {
    }

    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public decimal Price { get; private set; }
    public decimal PositionPrice { get; private set; }
}
