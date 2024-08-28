using TargovetsPlusAPI.Data;
using TargovetsPlusAPI.Models;
using TargovetsPlusAPI.Repositories.Interfaces;

namespace TargovetsPlusAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly TargovetsPlusDbContext _context;
    
    public ProductRepository(TargovetsPlusDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }
}