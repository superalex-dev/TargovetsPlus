using TargovetsPlusAPI.Models;

namespace TargovetsPlusAPI.Repositories.Interfaces;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int id);
}