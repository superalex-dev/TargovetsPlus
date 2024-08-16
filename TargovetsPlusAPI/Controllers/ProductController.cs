using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TargovetsPlusAPI.Data;
using TargovetsPlusAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly TargovetsPlusDbContext _context;

    public ProductController(TargovetsPlusDbContext context)
    {
        _context = context;
    }

    [HttpGet ("GetAllProducts")]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        return Ok(await _context.Products.ToListAsync());
    }

    [HttpGet("GetProductById/{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost ("CreateProduct")]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    [HttpPut("UpdateProduct/{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest("Product ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Products.Any(e => e.Id == id))
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

    [HttpDelete("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}