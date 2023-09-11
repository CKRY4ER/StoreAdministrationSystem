using StoreAdministrationSystem.ReadModel.PostgresSql.Context;

namespace StoreAdministrationSystem.ReadModel.PostgresSql;
public sealed class ReadModelQueryProvider<TReadModelItem> : IReadModelQueryProvider<TReadModelItem> where TReadModelItem : class, IReadModelItem
{
    private readonly IReadModelDbContext _context;

    public ReadModelQueryProvider(IReadModelDbContext context)
    {
        _context = context;
    }

    public IQueryable<TReadModelItem> Queryable => _context.Get<TReadModelItem>();
}
