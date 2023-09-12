using Microsoft.EntityFrameworkCore;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Products.Context.Configurations;
using StoreAdministrationSystem.Domain.Products;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Products.Context;

public sealed class ProductDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
}
