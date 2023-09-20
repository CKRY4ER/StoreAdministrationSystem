using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.Domain.Users;
using System.Text;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Users.Context.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.AggregateId);

        builder.Property(u => u.AggregateId)
            .HasColumnName("user_id");

        builder.Property(u => u.Email)
            .IsRequired()
            .HasColumnName("email")
            .HasMaxLength(64);

        builder.Property(u => u.Login)
            .IsRequired()
            .HasColumnName("login")
            .HasMaxLength(64);

        builder.Property(u => u.Password)
            .HasColumnName("password")
            .IsRequired()
            .HasConversion(
                v => Convert.ToBase64String(Encoding.UTF8.GetBytes(v)),
                v => Encoding.UTF8.GetString(Convert.FromBase64String(v)));

        builder.Property(p => p.IsAdmin)
            .HasColumnName("is_admin")
            .IsRequired();

        builder.Property(p => p.CreateDate)
            .HasColumnName("create_date")
            .IsRequired();

        builder.Property(p => p.UpdateDate)
            .HasColumnName("update_date")
            .IsRequired();

        builder.HasMany(p => p.Documents)
            .WithOne()
            .HasForeignKey("UserId")
            .HasPrincipalKey(u => u.AggregateId);

        builder.HasMany(p => p.ShoppingCartPositions)
            .WithOne()
            .HasForeignKey("UserId")
            .HasPrincipalKey(u => u.AggregateId);
    }
}
