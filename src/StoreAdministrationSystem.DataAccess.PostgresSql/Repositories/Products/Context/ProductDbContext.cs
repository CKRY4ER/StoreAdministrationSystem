using Microsoft.EntityFrameworkCore;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Products.Context.Configurations;
using StoreAdministrationSystem.Domain.Products;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Products.Context;

public sealed class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
}
