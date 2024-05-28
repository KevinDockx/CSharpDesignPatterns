using EnterprisePatterns.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace EnterprisePatterns.DbContexts;

public class OrderDbContext(DbContextOptions<OrderDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }

    // seed the database with data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasData(
            new("Shopping Spree") { Id = 1 },
            new("Holiday Shopping") { Id = 2 });

        modelBuilder.Entity<OrderLine>().HasData(
            new("Shoes", 1) { Id = 1, OrderId = 1 },
            new("Shirt", 2) { Id = 2, OrderId = 1 },
            new("Pants", 1) { Id = 3, OrderId = 1 },
            new("Socks", 5) { Id = 4, OrderId = 1 },
            new("Sunglasses", 1) { Id = 5, OrderId = 2 },
            new("Sunscreen", 2) { Id = 6, OrderId = 2 });       
         
        base.OnModelCreating(modelBuilder);
    }
}
