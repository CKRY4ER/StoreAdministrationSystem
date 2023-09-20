using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.Domain.Orders;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Orders.Context.Configurations;

public sealed class OrderPositionConfiguration : IEntityTypeConfiguration<OrderPosition>
{
    public void Configure(EntityTypeBuilder<OrderPosition> builder)
    {
        builder.ToTable("order_positions");

        builder.Property<Guid>("OrderId")
            .HasColumnName("order_id")
            .IsRequired();

        builder.HasKey("OrderId", "ProductId");

        builder.Property<Guid>("UserId")
            .IsRequired()
            .HasColumnName("user_id");

        builder.Property<Guid>("ProductId")
            .IsRequired()
            .HasColumnName("product_id");

        builder.Property(op => op.Price)
            .HasColumnName("price")
            .IsRequired();
        
        builder.Property(op => op.Count)
            .HasColumnName("count")
            .IsRequired();

        builder.Property(op => op.PositionPrice)
            .HasColumnName("position_price")
            .IsRequired();

        builder.HasOne(op => op.Product)
            .WithMany()
            .HasForeignKey(op => op.ProductId);
    }
}
