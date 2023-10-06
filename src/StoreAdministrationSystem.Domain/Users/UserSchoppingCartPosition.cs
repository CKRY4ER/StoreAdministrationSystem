using StoreAdministrationSystem.Domain.Products;

namespace StoreAdministrationSystem.Domain.Users;

public sealed class UserSchoppingCartPosition
{
    public UserSchoppingCartPosition(Guid productId, int productCount)
    {
        ProductId = productId;
        ProductCount = productCount;
    }

    public Guid ProductId { get; private set; }
    public int ProductCount { get; private set; } 
    public Product Product { get; private set; } = null!;

    public void AddProduct(int productCount)
        => ProductCount += productCount;

    public void ReduceProduct(int productCount)
        => ProductCount -= productCount;
}
