using Microsoft.EntityFrameworkCore;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.ProductCategories.Context;
using StoreAdministrationSystem.DataAccess.Repositories.ProductCategories;
using StoreAdministrationSystem.Domain.ProductCategories;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.ProductCategories;

public sealed class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly ProductCategoriesDbContext _contex;

    public ProductCategoryRepository(ProductCategoriesDbContext contex)
        => _contex = contex;

    public async Task<ProductCategory?> GetByidAsync(Guid productCategoryId, CancellationToken cancellationToken)
        => await _contex.ProductCategories
            .AsSplitQuery()
            .FirstOrDefaultAsync(pc => pc.AggregateId == productCategoryId, cancellationToken);

    public async Task<ProductCategory?> GetByNameAsync(string name, CancellationToken cancellationToken)
        => await _contex.ProductCategories
            .AsSplitQuery()
            .FirstOrDefaultAsync(pc => pc.Name == name ,cancellationToken);

    public async Task SaveAsync(ProductCategory aggregate, CancellationToken cancellationToken)
    {
        await _contex.AddAsync(aggregate, cancellationToken);
        await _contex.SaveChangesAsync(cancellationToken);
    }
}
