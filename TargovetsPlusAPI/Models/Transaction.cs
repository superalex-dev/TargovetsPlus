namespace TargovetsPlusAPI.Models;

public class Transaction
{
    public int Id { get; set; }
    
    public DateTime TransactionDate { get; set; }
    
    public decimal TotalAmount { get; set; }
    
    public int ShopId { get; set; }
    public Shop Shop { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public List<TransactionItem> TransactionItems { get; set; }
}