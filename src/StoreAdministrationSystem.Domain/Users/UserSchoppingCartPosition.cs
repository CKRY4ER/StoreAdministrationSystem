using StoreAdministrationSystem.Domain.Products;

namespace StoreAdministrationSystem.Domain.Users;

public sealed class UserSchoppingCartPosition
{
    private UserSchoppingCartPosition() { } 

    public UserSchoppingCartPosition(Guid productId, int productCount, decimal totalPrice)
    {
        ProductId = productId;
        ProductCount = productCount;
        TotalPrice = totalPrice;
    }

    public Guid ProductId { get; private set; }
    public int ProductCount { get; private set; } 
    public decimal TotalPrice { get; private set; }
    public Product Product { get; private set; }
}
