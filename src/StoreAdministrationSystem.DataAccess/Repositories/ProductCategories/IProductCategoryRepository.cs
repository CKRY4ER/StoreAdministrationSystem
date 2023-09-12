using StoreAdministrationSystem.Domain.ProductCategories;

namespace StoreAdministrationSystem.DataAccess.Repositories.ProductCategories;

public interface IProductCategoryRepository : IRepository<ProductCategory>
{
    Task<ProductCategory?> GetByNameAsync(string name, CancellationToken cancellationToken);

    Task<ProductCategory?> GetByidAsync(Guid productCategoryId, CancellationToken cancellationToken);
}
