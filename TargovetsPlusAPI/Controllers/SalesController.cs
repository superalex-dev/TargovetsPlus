using Microsoft.AspNetCore.Mvc;
using TargovetsPlusAPI.Models;
using TargovetsPlusAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TargovetsPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        // POST: api/Sales
        [HttpPost("CreateSale")]
        public async Task<ActionResult<Sale>> CreateSale(Sale sale, [FromQuery] bool isAgeConfirmed)
        {
            // Age verification logic
            foreach (var productId in sale.ProductIds)
            {
                var product = await _salesService.GetProductByIdAsync(productId);
                if (product.Category.ToString() == "alcohol" || product.Category.ToString() == "tobacco")
                {
                    if (!isAgeConfirmed)
                    {
                        return BadRequest("Age confirmation is required for restricted products");
                    }
                }
            }

            await _salesService.AddSaleAsync(sale);
            return CreatedAtAction(nameof(GetSaleById), new { id = sale.Id }, sale);
        }

        // GET: api/Sales/5
        [HttpGet("GetSaleById/{id}")]
        public async Task<ActionResult<Sale>> GetSaleById(int id)
        {
            var sale = await _salesService.GetSaleByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        // GET: api/Sales/Reports/Daily
        [HttpGet("Reports/Daily")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetDailySalesReport()
        {
            var sales = await _salesService.GetSalesReportAsync("daily");
            return Ok(sales);
        }

        // GET: api/Sales/Reports/Weekly
        [HttpGet("Reports/Weekly")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetWeeklySalesReport()
        {
            var sales = await _salesService.GetSalesReportAsync("weekly");
            return Ok(sales);
        }

        // GET: api/Sales/Reports/Monthly
        [HttpGet("Reports/Monthly")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetMonthlySalesReport()
        {
            var sales = await _salesService.GetSalesReportAsync("monthly");
            return Ok(sales);
        }
    }
}