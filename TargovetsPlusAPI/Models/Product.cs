namespace TargovetsPlusAPI.Models;

public class Product
{
    public int Id { get; set; }
    
    public string ProductName { get; set; }
    
    public string Barcode { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal Price { get; set; }
    
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }
}