﻿using Microsoft.EntityFrameworkCore;
using StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Orders.Context.Configurations;
using StoreAdministrationSystem.Domain.Orders;

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Repositories.Orders.Context;

public sealed class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderPositionConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Order> Orders { get; set; }
}
