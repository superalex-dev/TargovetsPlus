﻿using Microsoft.EntityFrameworkCore;
using TargovetsPlusAPI.Models;

namespace TargovetsPlusAPI.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly TargovetsPlusAPIDbContext _context;

    public ProductRepository(TargovetsPlusAPIDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int productId)
    {
        return await _context.Products.FindAsync(productId);
    }

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}