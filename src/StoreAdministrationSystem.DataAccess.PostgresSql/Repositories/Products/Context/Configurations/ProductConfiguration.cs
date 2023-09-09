using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.Domain.Products;
using System.Text.Json;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Products.Context.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Metadata.AddProperty("ProductCategoryId", typeof(Guid));

        builder.ToTable("products");

        builder.HasKey(p => p.AggregateId);

        builder.Property(p => p.AggregateId)
            .HasColumnName("product_id");

        builder.Property<Guid>("ProductCategoryId")
            .HasColumnName("product_category_id")
            .IsRequired();

        builder.Property(p => p.ProductName)
            .HasColumnName("product_name")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasMaxLength(1500);

        builder.Property(p => p.Price)
            .HasColumnName("price")
            .IsRequired();

        builder.Property(p => p.Count)
            .HasColumnName("count")
            .IsRequired();

        builder.Property(p => p.ProductPictureUrl)
            .HasColumnName("product_picture_url")
            .HasConversion(
                v => v.ToString(),
                v => new Uri(v))
            .IsRequired();

        builder.Property(p => p.Parameters)
            .HasColumnName("parameters")
            .IsRequired()
            .HasConversion(
                v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, new JsonSerializerOptions())!);


        builder.Property(p => p.CreateDate)
            .HasColumnName("create_date");

        builder.Property(p => p.UpdateDate)
            .HasColumnName("update_date");

        builder.HasOne(p => p.ProductCategory)
            .WithMany()
            .HasForeignKey("ProductCategoryId");
    }
}
