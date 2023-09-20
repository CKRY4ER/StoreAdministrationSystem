using Microsoft.EntityFrameworkCore;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Products.Context;
using StoreAdministrationSystem.DataAccess.Repositories.Products;
using StoreAdministrationSystem.Domain.Products;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Products;

public sealed class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken)
        => await _context.Products.AsSplitQuery()
            .Include(p => p.ProductCategory)
            .FirstOrDefaultAsync(p => p.AggregateId == productId, cancellationToken);

    public async Task<Product?> GetByName(string Name, CancellationToken cancellationToken)
        => await _context.Products.AsSplitQuery()
        .Include(p => p.ProductCategory)
        .FirstOrDefaultAsync(p => p.ProductName == Name);

    public async Task SaveAsync(Product aggregate, CancellationToken cancellationToken)
    {
        await _context.AddAsync(aggregate, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
