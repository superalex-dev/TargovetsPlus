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
        
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<Transaction> Transactions { get; set; }
        
        public DbSet<Alert> Alerts { get; set; }
        
        public DbSet<Sale> Sales { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.Id);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "Owner" },
                new Role { Id = 3, RoleName = "Employee" }
            );
        }
    }
}