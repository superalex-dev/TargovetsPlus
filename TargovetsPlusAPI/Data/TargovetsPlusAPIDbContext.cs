using Microsoft.EntityFrameworkCore;
using TargovetsPlusAPI.Models;

namespace TargovetsPlusAPI.Data;

public class TargovetsPlusAPIDbContext : DbContext
{
    public TargovetsPlusAPIDbContext(DbContextOptions<TargovetsPlusAPIDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Shop> Shops { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<TransactionItem> TransactionItems { get; set; }

    public DbSet<InventoryLog> InventoryLogs { get; set; }

    public DbSet<Notification> Notifications { get; set; }
}
