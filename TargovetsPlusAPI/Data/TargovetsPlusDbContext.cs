using Microsoft.EntityFrameworkCore;
using TargovetsPlusAPI.Models;

namespace TargovetsPlusAPI.Data
{
    public class TargovetsPlusDbContext : DbContext
    {
        public TargovetsPlusDbContext(DbContextOptions<TargovetsPlusDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany()
                .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.ProductId);
        }
    }
}