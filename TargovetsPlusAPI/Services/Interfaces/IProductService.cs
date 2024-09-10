using TargovetsPlusAPI.Data.Dto;
using TargovetsPlusAPI.Models;

namespace TargovetsPlusAPI.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();

    Task<Product> GetProductByIdAsync(int productId);

    Task AddProductAsync(ProductDto productDto);

    Task UpdateProductAsync(int productId, ProductDto productDto);

    Task DeleteProductAsync(int productId);
}