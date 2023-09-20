using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace StoreAdministrationSystem.ReadModel.PostgresSql;

public sealed class ReadModelQueryExecutor : IReadModelQueryExecutor
{
    public async Task<bool> AnyAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default(CancellationToken))
        => await source.AnyAsync(cancellationToken);

    public async Task<T> FirstAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default(CancellationToken))
        => await source.FirstAsync(cancellationToken);

    public async Task<long> CountAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default(CancellationToken))
        => await source.LongCountAsync(cancellationToken);

    public async Task<T?> FirstOrDefaultAsync<T>(IQueryable<T?> source, CancellationToken cancellationToken = default(CancellationToken))
        => await source.FirstOrDefaultAsync(cancellationToken);

    public async Task<T> SingleAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default(CancellationToken))
        => await source.SingleAsync(cancellationToken);

    public async Task<T?> SingleOrDefaultAsync<T>(IQueryable<T?> source, CancellationToken cancellationToken = default(CancellationToken))
        => await source.SingleOrDefaultAsync(cancellationToken);

    public async Task<T[]> ToArrayAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default(CancellationToken))
        => await source.ToArrayAsync(cancellationToken);

    public async Task<List<T>> ToListAsync<T>(IQueryable<T> source, CancellationToken cancellationToken = default(CancellationToken))
        => await source.ToListAsync(cancellationToken);
}
