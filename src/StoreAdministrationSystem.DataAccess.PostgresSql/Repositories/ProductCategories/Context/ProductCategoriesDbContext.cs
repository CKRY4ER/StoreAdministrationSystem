using Microsoft.EntityFrameworkCore;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.ProductCategories.Context.Configurations;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.ProductCategories.Context;

public sealed class ProductCategoriesDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());

        base.OnModelCreating(modelBuilder); 
    }
}
