namespace TargovetsPlusAPI.Models;

public class Product
{
    public int Id { get; set; }
    
    public string ProductName { get; set; }
    
    public string Category { get; set; }
    
    public decimal Price { get; set; }
    
    public string Barcode { get; set; }
    
    public int StockQuantity { get; set; }
    
    public int ShopId { get; set; }
    public Shop Shop { get; set; }
    
    public List<TransactionItem> TransactionItems { get; set; }
    public List<InventoryLog> InventoryLogs { get; set; }
}
