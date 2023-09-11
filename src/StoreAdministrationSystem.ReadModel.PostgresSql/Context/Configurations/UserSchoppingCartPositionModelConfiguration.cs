using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.ReadModel.Users;

namespace StoreAdministrationSystem.ReadModel.PostgresSql.Context.Configurations;

public sealed class UserSchoppingCartPositionModelConfiguration : IEntityTypeConfiguration<UserSchoppingCartPositionModelItem>
{
    public void Configure(EntityTypeBuilder<UserSchoppingCartPositionModelItem> builder)
    {
        builder.ToTable("user_schopping_cart_positions");

        builder.HasKey(usc => new { usc.ProductId, usc.UserId });
    }
}
