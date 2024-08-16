using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TargovetsPlusAPI.Data;
using TargovetsPlusAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly TargovetsPlusDbContext _context;

    public InventoryController(TargovetsPlusDbContext context)
    {
        _context = context;
    }

    [HttpGet ("GetAllInventoryItems")]
    public async Task<ActionResult<IEnumerable<Inventory>>> GetAllInventoryItems()
    {
        var inventoryItems = await _context.Inventory
            .Include(i => i.Product)
            .ToListAsync();
        return Ok(inventoryItems);
    }

    [HttpGet("GetInventoryItemById/{id}")]
    public async Task<ActionResult<Inventory>> GetInventoryItemById(int id)
    {
        var inventoryItem = await _context.Inventory
            .Include(i => i.Product)
            .FirstOrDefaultAsync(i => i.Id == id);

        if (inventoryItem == null)
        {
            return NotFound();
        }

        return Ok(inventoryItem);
    }

    [HttpPost ("CreateInventoryItem")]
    public async Task<ActionResult<Inventory>> CreateInventoryItem(Inventory inventory)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Inventory.Add(inventory);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetInventoryItemById), new { id = inventory.Id }, inventory);
    }

    [HttpPut("UpdateInventoryItem/{id}")]
    public async Task<IActionResult> UpdateInventoryItem(int id, Inventory inventory)
    {
        if (id != inventory.Id)
        {
            return BadRequest("Inventory ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Entry(inventory).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Inventory.Any(e => e.Id == id))
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

    [HttpDelete("DeleteInventoryItem/{id}")]
    public async Task<IActionResult> DeleteInventoryItem(int id)
    {
        var inventoryItem = await _context.Inventory.FindAsync(id);
        if (inventoryItem == null)
        {
            return NotFound();
        }

        _context.Inventory.Remove(inventoryItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}