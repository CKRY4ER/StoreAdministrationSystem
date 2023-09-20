using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.ReadModel.Orders;

namespace StoreAdministrationSystem.ReadModel.PostgresSql.Context.Configurations;

internal sealed class OrderModelConfiguration : IEntityTypeConfiguration<OrderModelItem>
{
    public void Configure(EntityTypeBuilder<OrderModelItem> builder)
    {
        builder.ToTable("orders");
        builder.HasKey(o => o.OrderId);
    }
}

