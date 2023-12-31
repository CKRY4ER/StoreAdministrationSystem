﻿using Microsoft.EntityFrameworkCore;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Users.Context;
using StoreAdministrationSystem.DataAccess.Repositories.Users;
using StoreAdministrationSystem.Domain.Users;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Users;

public sealed class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
        => await _context.Users.AsSplitQuery()
            .Include(u => u.Documents)
            .Include(u => u.ShoppingCartPositions)
            .FirstOrDefaultAsync(u => u.AggregateId == userId, cancellationToken);

    public async Task SaveAsync(User aggregate, CancellationToken cancellationToken)
    {
        await _context.AddAsync(aggregate, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
