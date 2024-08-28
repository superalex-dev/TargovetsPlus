namespace TargovetsPlusAPI.Models;

public class Transaction
{
    public int Id { get; set; }
    
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal TotalAmount { get; set; }
    
    public string PaymentMethod { get; set; }
    
    public DateTime TransactionDate { get; set; }
}