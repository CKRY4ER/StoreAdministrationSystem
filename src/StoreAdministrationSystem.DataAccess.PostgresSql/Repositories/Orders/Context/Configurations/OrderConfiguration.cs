using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.Domain.Orders;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Orders.Context.Configurations;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");
        builder.HasKey(order => order.AggregateId);

        builder.Property(order => order.TotalPrice)
            .HasColumnName("total_price")
            .IsRequired();

        builder.Property(o => o.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(order => order.AggregateId)
            .HasColumnName("order_id")
            .IsRequired();

        builder.Property(order => order.OrderStatus)
            .HasColumnName("order_status")
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(order => order.CreateDate)
            .HasColumnName("created_date")
            .IsRequired();

        builder.Property(order => order.UpdateDate)
            .HasColumnName("update_date");

        builder.HasMany(order => order.OrderPositions)
            .WithOne()
            .HasForeignKey("OrderId")
            .HasPrincipalKey(order => order.AggregateId);
    }
}
