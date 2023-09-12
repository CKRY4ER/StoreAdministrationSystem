using StoreAdministrationSystem.Domain.Users;

namespace StoreAdministrationSystem.DataAccess.Repositories.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
}
