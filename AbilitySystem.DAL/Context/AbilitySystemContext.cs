using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public class AbilitySystemContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();

    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
    public DbSet<Wishlist> Wishlist => Set<Wishlist>();

    public AbilitySystemContext(DbContextOptions<AbilitySystemContext> options)
        : base(options)
    {

    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    #region seeding
    //    //modelBuilder.Entity<Department>().HasData(departments);
    //    //modelBuilder.Entity<Ticket>().HasData(tickets);
    //    //modelBuilder.Entity<Developer>().HasData(developers);
    //    #endregion
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
