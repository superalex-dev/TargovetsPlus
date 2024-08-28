using System.Data.Entity;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using TargovetsPlusAPI.Data;
using TargovetsPlusAPI.Models;
using TargovetsPlusAPI.Repositories.Interfaces;

namespace TargovetsPlusAPI.Repositories;

public class SalesRepository : ISalesRepository
{
    private readonly TargovetsPlusDbContext _context;
    
    public SalesRepository(TargovetsPlusDbContext context)
    {
        _context = context;
    }
    
    public async Task AddSaleAsync(Sale sale)
    {
        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();
    }

    public async Task<Sale> GetSaleByIdAsync(int id)
    {
        return await _context.Sales.FindAsync(id);
    }

    public async Task<IEnumerable<Sale>> GetSalesReportAsync(string period)
    {
        var query = _context.Sales.AsQueryable();

        switch (period.ToLower())
        {
            case "daily":
                query = query.Where(s => s.DateOfPurchase.Date == DateTime.Today);
                break;
            case "weekly":
                var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                query = query.Where(s => s.DateOfPurchase.Date >= startOfWeek);
                break;
            case "monthly":
                query = query.Where(s => s.DateOfPurchase.Month == DateTime.Today.Month && s.DateOfPurchase.Year == DateTime.Today.Year);
                break;
        }

        return await query.ToListAsync();
    }
}