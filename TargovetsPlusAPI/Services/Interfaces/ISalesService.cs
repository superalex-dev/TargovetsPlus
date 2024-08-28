using TargovetsPlusAPI.Models;

namespace TargovetsPlusAPI.Services.Interfaces;

public interface ISalesService
{
    Task AddSaleAsync(Sale sale);
    Task<Sale> GetSaleByIdAsync(int id);
    Task<IEnumerable<Sale>> GetSalesReportAsync(string period);
    Task<Product> GetProductByIdAsync(int id);
}