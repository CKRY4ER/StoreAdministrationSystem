namespace StoreAdministrationSystem.ReadModel;

public interface IReadModelQueryExecutor
{
    Task<long> CountAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default(CancellationToken));

    Task<bool> AnyAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default(CancellationToken));

    Task<T> FirstAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default(CancellationToken));

    Task<T?> FirstOrDefaultAsync<T>(IQueryable<T?> source, CancellationToken cancellationToken = default(CancellationToken));

    Task<T> SingleAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default(CancellationToken));

    Task<T?> SingleOrDefaultAsync<T>(IQueryable<T?> source, CancellationToken cancellationToken = default(CancellationToken));

    Task<List<T>> ToListAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default(CancellationToken));

    Task<T[]> ToArrayAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default(CancellationToken));
}
