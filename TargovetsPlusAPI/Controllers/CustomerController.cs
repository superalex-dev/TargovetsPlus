using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TargovetsPlusAPI.Data;
using TargovetsPlusAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly TargovetsPlusDbContext _context;

    public CustomerController(TargovetsPlusDbContext context)
    {
        _context = context;
    }

    [HttpGet ("GetAllCustomers")]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
    {
        return Ok(await _context.Customers.ToListAsync());
    }

    [HttpGet("GetCustomerById/{id}")]
    public async Task<ActionResult<Customer>> GetCustomerById(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost ("CreateCustomer")]
    public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }

    [HttpPut("UpdateCustomer/{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
    {
        if (id != customer.Id)
        {
            return BadRequest("Customer ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Entry(customer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Customers.Any(e => e.Id == id))
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

    [HttpDelete("DeleteCustomer/{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}