using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreAdministrationSystem.Domain.Users;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Users.Context.Configurations;

internal sealed class UserDocumentConfiguration : IEntityTypeConfiguration<UserDocument>
{
    public void Configure(EntityTypeBuilder<UserDocument> builder)
    {

        builder.ToTable("user_documents");

        builder.Property<Guid>("UserId")
            .HasColumnName("user_id")
            .IsRequired();

        builder.HasKey("UserId", "DocumentId");

        builder.Property(ud => ud.DocumentId)
            .HasColumnName("document_id");
    }
}
