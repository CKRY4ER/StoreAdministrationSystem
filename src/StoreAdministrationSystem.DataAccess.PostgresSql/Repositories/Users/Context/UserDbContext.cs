using Microsoft.EntityFrameworkCore;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Users.Context.Configurations;
using StoreAdministrationSystem.Domain.Users;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Users.Context;

public sealed class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserDocumentConfiguration());
        modelBuilder.ApplyConfiguration(new UserSchoppingCartPositionConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
}
