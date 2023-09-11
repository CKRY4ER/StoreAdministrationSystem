using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.ReadModel.ProductCategories;

namespace StoreAdministrationSystem.ReadModel.PostgresSql.Context.Configurations;

public sealed class ProductCategoryModelConfiguration : IEntityTypeConfiguration<ProductCategoryModelItem>
{
    public void Configure(EntityTypeBuilder<ProductCategoryModelItem> builder)
    {
        builder.ToTable("product_categories");
        builder.HasKey(pc => pc.ProductCategoryId);
    }
}
