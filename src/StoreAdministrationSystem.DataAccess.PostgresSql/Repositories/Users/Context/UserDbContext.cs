using Microsoft.EntityFrameworkCore;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Users.Context.Configurations;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Users.Context;

public sealed class UserDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserDocumentConfiguration());
        modelBuilder.ApplyConfiguration(new UserSchoppingCartPositionConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
