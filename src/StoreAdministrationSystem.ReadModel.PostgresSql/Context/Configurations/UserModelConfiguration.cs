using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.ReadModel.Users;
using System.Text;

namespace StoreAdministrationSystem.ReadModel.PostgresSql.Context.Configurations;

public sealed class UserModelConfiguration : IEntityTypeConfiguration<UserModelItem>
{
    public void Configure(EntityTypeBuilder<UserModelItem> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.UserId);

        builder.Property(u => u.Password)
            .HasConversion(
                v => Convert.ToBase64String(Encoding.UTF8.GetBytes(v)),
                v => Encoding.UTF8.GetString(Convert.FromBase64String(v)));
    }
}
