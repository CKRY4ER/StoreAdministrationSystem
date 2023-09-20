using StoreAdministrationSystem.Domain.Products;

namespace StoreAdministrationSystem.Domain.Orders;

public sealed class OrderPosition
{
    private OrderPosition() { }

    public OrderPosition(Guid productId, decimal price, int count, decimal positionPrice)
    {
        ProductId = productId;
        Price = price;
        Count = count;
        PositionPrice = positionPrice;
    }

    public Guid ProductId { get; private set; }
    public decimal Price { get; private set; }
    public int Count { get; private set; }
    public decimal PositionPrice { get; private set; }
    public Product Product { get; private set; } = null!;
}
