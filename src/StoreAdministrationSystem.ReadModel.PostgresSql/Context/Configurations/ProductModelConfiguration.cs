using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.ReadModel.Products;
using System.Text.Json;

namespace StoreAdministrationSystem.ReadModel.PostgresSql.Context.Configurations;

public sealed class ProductModelConfiguration : IEntityTypeConfiguration<ProductModelItem>
{
    public void Configure(EntityTypeBuilder<ProductModelItem> builder)
    {
        builder.ToTable("products");
        builder.HasKey(p => p.ProductId);

        builder.Property(p => p.Parameters)
            .HasConversion(
            v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
            v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, new JsonSerializerOptions())!);
    }
}
