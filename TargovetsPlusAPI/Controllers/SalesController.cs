using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TargovetsPlusAPI.Data;
using TargovetsPlusAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly TargovetsPlusDbContext _context;

    public SalesController(TargovetsPlusDbContext context)
    {
        _context = context;
    }

    [HttpGet ("GetAllSales")]
    public async Task<ActionResult<IEnumerable<Sale>>> GetAllSales()
    {
        var sales = await _context.Sales
            .Include(s => s.Customer)
            .Include(s => s.Product)
            .ToListAsync();
        return Ok(sales);
    }

    [HttpGet("GetSaleById/{id}")]
    public async Task<ActionResult<Sale>> GetSaleById(int id)
    {
        var sale = await _context.Sales
            .Include(s => s.Customer)
            .Include(s => s.Product)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (sale == null)
        {
            return NotFound();
        }

        return Ok(sale);
    }

    [HttpPost ("CreateSale")]
    public async Task<ActionResult<Sale>> CreateSale(Sale sale)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var product = await _context.Products.FindAsync(sale.ProductId);
        if (product == null)
        {
            return BadRequest("Product not found.");
        }

        var inventory = await _context.Inventory.FirstOrDefaultAsync(i => i.ProductId == product.Id);
        if (inventory == null || inventory.Quantity < 1)
        {
            return BadRequest("Insufficient inventory.");
        }

        inventory.Quantity -= 1;
        _context.Entry(inventory).State = EntityState.Modified;

        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSaleById), new { id = sale.Id }, sale);
    }

    [HttpPut("UpdateSale/{id}")]
    public async Task<IActionResult> UpdateSale(int id, Sale sale)
    {
        if (id != sale.Id)
        {
            return BadRequest("Sale ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Entry(sale).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Sales.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("DeleteSale/{id}")]
    public async Task<IActionResult> DeleteSale(int id)
    {
        var sale = await _context.Sales.FindAsync(id);
        if (sale == null)
        {
            return NotFound();
        }

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}