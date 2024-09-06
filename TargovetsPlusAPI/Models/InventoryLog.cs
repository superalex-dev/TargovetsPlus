namespace TargovetsPlusAPI.Models;

public class InventoryLog
{
    public int Id { get; set; }
    
    public DateTime LogDate { get; set; }
    
    public int ChangeQuantity { get; set; }
    
    public string ChangeType { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
}