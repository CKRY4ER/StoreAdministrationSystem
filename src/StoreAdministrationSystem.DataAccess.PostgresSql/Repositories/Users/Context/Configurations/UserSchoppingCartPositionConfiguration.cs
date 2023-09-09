using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.Domain.Users;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Users.Context.Configurations;

internal sealed class UserSchoppingCartPositionConfiguration : IEntityTypeConfiguration<UserSchoppingCartPosition>
{
    public void Configure(EntityTypeBuilder<UserSchoppingCartPosition> builder)
    {
        builder.ToTable("user_schopping_cart_positions");

        builder.Property<Guid>("UserId")
            .HasColumnName("user_id")
            .IsRequired();

        builder.HasKey("ProductId", "UserId");

        builder.Property(uscp => uscp.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        builder.Property(uscp => uscp.TotalPrice)
            .HasColumnName("total_price")
            .IsRequired();

        builder.Property(uscp => uscp.ProductCount)
            .HasColumnName("product_count");

        builder.HasOne(uscp => uscp.Product)
            .WithMany()
            .HasForeignKey(uscp => uscp.ProductId);
    }
}
