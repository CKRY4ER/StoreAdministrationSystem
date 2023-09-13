using Microsoft.EntityFrameworkCore;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.ProductCategories.Context.Configurations;
using StoreAdministrationSystem.Domain.ProductCategories;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.ProductCategories.Context;

public sealed class ProductCategoriesDbContext : DbContext
{
    public ProductCategoriesDbContext(DbContextOptions<ProductCategoriesDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());

        base.OnModelCreating(modelBuilder); 
    }

    public DbSet<ProductCategory> ProductCategories { get; set; }
}
