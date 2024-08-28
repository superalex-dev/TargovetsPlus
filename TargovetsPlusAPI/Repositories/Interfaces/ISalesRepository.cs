using TargovetsPlusAPI.Models;

namespace TargovetsPlusAPI.Repositories.Interfaces;

public interface ISalesRepository
{
    Task AddSaleAsync(Sale sale);
    
    Task<Sale> GetSaleByIdAsync(int id);
    
    Task<IEnumerable<Sale>> GetSalesReportAsync(string period);
}