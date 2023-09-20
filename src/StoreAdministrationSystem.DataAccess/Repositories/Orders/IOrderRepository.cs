using StoreAdministrationSystem.Domain.Orders;

namespace StoreAdministrationSystem.DataAccess.Repositories.Orders;

public interface IOrderRepository : IRepository<Order>
{
    Task<Order?> GetByIdAsync(Guid orderId, CancellationToken cancellationToken);
}
