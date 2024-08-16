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
        
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     var configuration = new ConfigurationBuilder()
        //         .SetBasePath(Directory.GetCurrentDirectory())
        //         .AddJsonFile("appsettings.json")
        //         .Build();
        //     
        //     string connectionString = configuration.GetConnectionString("DefaultConnection");
        //     optionsBuilder.UseNpgsql(connectionString);
        // }
    }
}