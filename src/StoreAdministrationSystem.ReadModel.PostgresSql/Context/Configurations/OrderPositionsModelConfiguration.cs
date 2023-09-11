using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.ReadModel.Orders;

namespace StoreAdministrationSystem.ReadModel.PostgresSql.Context.Configurations;

internal sealed class OrderPositionsModelConfiguration : IEntityTypeConfiguration<OrderPositionModelItem>
{
    public void Configure(EntityTypeBuilder<OrderPositionModelItem> builder)
    {
        builder.ToTable("order_positions");
        builder.HasKey(op => new { op.OrderId, op.ProductId });
    }
}
