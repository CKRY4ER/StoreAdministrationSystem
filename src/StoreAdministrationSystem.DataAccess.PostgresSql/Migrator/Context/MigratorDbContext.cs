using Microsoft.EntityFrameworkCore;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Migrator.Context;

public sealed class MigratorDbContext : DbContext
{
    public MigratorDbContext(DbContextOptions<MigratorDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MigratorDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
