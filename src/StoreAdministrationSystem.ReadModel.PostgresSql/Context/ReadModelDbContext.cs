using Microsoft.EntityFrameworkCore;

namespace StoreAdministrationSystem.ReadModel.PostgresSql.Context;

internal class ReadModelDbContext : DbContext, IReadModelDbContext
{
    public ReadModelDbContext(DbContextOptions<ReadModelDbContext> options) : base(options)
        => ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReadModelDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<TReadModelItem> Get<TReadModelItem>() where TReadModelItem : class, IReadModelItem
        => Set<TReadModelItem>();
}


public interface IReadModelDbContext 
{
    DbSet<TReadModelItem> Get<TReadModelItem>() where TReadModelItem : class, IReadModelItem;
}
