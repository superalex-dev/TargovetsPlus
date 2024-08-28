using TargovetsPlusAPI.Models;
using TargovetsPlusAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using TargovetsPlusAPI.Repositories.Interfaces;
using TargovetsPlusAPI.Services.Interfaces;

namespace TargovetsPlusAPI.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IProductRepository _productRepository;

        public SalesService(ISalesRepository salesRepository, IProductRepository productRepository)
        {
            _salesRepository = salesRepository;
            _productRepository = productRepository;
        }

        public async Task AddSaleAsync(Sale sale)
        {
            // Age verification logic
            foreach (var productId in sale.ProductIds)
            {
                var product = await _productRepository.GetProductByIdAsync(productId);
                if (product.Category.ToString() == "alcohol" || product.Category.ToString() == "tobacco")
                {
                    if (sale.CustomerAge < 18)
                    {
                        throw new InvalidOperationException("Customer is not old enough to purchase restricted products");
                    }
                }
            }

            await _salesRepository.AddSaleAsync(sale);
        }

        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await _salesRepository.GetSaleByIdAsync(id);
        }

        public async Task<IEnumerable<Sale>> GetSalesReportAsync(string period)
        {
            return await _salesRepository.GetSalesReportAsync(period);
        }
        
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }
    }
}