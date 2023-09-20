using StoreAdministrationSystem.Domain;

namespace StoreAdministrationSystem.DataAccess.Repositories;

public interface IRepository<TAggregate>  where TAggregate : Aggregate
{
    Task SaveAsync(TAggregate aggregate, CancellationToken cancellationToken);
}
