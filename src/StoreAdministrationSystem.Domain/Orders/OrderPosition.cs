namespace StoreAdministrationSystem.Domain.Orders;

public sealed class OrderPosition
{
    private OrderPosition() { }

    public OrderPosition(Guid productId, decimal price, int count)
    {
        ProductId = productId;
        Price = price;
        Count = count;
    }

    public Guid ProductId { get; private set; }

    public decimal Price { get; private set; }

    public int Count { get; private set; }
}
