using System.ComponentModel.DataAnnotations.Schema;

namespace TargovetsPlusAPI.Models;

public class Sale
{
    public int Id { get; set; }
    
    public List<int> ProductIds { get; set; }
    
    public decimal TotalAmount { get; set; }
    
    public DateTime DateOfPurchase { get; set; }
    
    [NotMapped]
    public int CustomerAge { get; set; }
}