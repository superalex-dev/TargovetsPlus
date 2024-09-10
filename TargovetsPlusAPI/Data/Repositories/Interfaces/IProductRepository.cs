using TargovetsPlusAPI.Models;

namespace TargovetsPlusAPI.Data.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product> GetByIdAsync(int productId);

    Task AddAsync(Product product);

    Task UpdateAsync(Product product);

    Task DeleteAsync(Product product);
}