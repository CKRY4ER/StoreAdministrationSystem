using Microsoft.EntityFrameworkCore;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Orders.Context;
using StoreAdministrationSystem.DataAccess.Repositories.Orders;
using StoreAdministrationSystem.Domain.Orders;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Orders;

public sealed class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _context;

    public OrderRepository(OrderDbContext context)
        => _context = context;

    public async Task<Order?> GetByIdAsync(Guid orderId, CancellationToken cancellationToken)
        => await _context.Orders
            .AsSplitQuery()
            .Include(o => o.OrderPositions)
            .FirstOrDefaultAsync(o => o.AggregateId == orderId, cancellationToken);

    public async Task SaveAsync(Order aggregate, CancellationToken cancellationToken)
    {
        await _context.AddRangeAsync(aggregate, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
