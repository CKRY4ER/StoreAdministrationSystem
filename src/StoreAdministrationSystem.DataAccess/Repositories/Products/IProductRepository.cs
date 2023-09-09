using StoreAdministrationSystem.Domain.Products;

namespace StoreAdministrationSystem.DataAccess.Repositories.Products;

public interface IProductRepository : IRepository<Product>
{
    Task<Product> GetByIdAsync(Guid productId, CancellationToken cancellationToken);
}
