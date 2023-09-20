using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.Domain.ProductCategories;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.ProductCategories.Context.Configurations;

internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("product_categories");

        builder.HasKey(pc => pc.AggregateId);

        builder.Property(pc => pc.AggregateId)
            .HasColumnName("product_category_id");

        builder.Property(pc => pc.Name)
            .HasColumnName("name")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(pc => pc.CreateDate)
            .IsRequired()
            .HasColumnName("create_date");

        builder.Property(pc => pc.UpdateDate)
            .IsRequired()
            .HasColumnName("update_date");
    }
}
