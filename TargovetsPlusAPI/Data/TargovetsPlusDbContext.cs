using Microsoft.EntityFrameworkCore;

namespace TargovetsPlusAPI.Data
{
    public class TargovetsPlusDbContext : DbContext
    {
        public TargovetsPlusDbContext(DbContextOptions<TargovetsPlusDbContext> options)
            : base(options)
        {
        }
    }
}