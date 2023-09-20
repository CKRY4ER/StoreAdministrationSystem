using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.ReadModel.Users;

namespace StoreAdministrationSystem.ReadModel.PostgresSql.Context.Configurations;

public sealed class UserDocumentModelConfiguration : IEntityTypeConfiguration<UserDocumentModelItem>
{
    public void Configure(EntityTypeBuilder<UserDocumentModelItem> builder)
    {
        builder.ToTable("user_documents");

        builder.HasKey(ud => new { ud.UserId, ud.DocumentId });
    }
}
