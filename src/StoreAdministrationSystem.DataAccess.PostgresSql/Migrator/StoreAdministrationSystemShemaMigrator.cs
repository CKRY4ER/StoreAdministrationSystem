using Microsoft.EntityFrameworkCore;
using StoreAdministrationSystem.DataAccess.PostgresSql.Migrator.Context;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Migrator;

public sealed class StoreAdministrationSystemShemaMigrator : IStoreAdministrationSystemShemaMigrator
{
    private readonly MigratorDbContext _dbContext;

    public StoreAdministrationSystemShemaMigrator(MigratorDbContext dbContext)
        => _dbContext = dbContext;

    public async Task MigrateAsync()
        => await _dbContext.Database.MigrateAsync();
}

public interface IStoreAdministrationSystemShemaMigrator
{
    Task MigrateAsync();
}
