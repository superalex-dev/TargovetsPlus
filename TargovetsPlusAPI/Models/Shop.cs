namespace TargovetsPlusAPI.Models;

public class Shop
{
    public int Id { get; set; }
    
    public string ShopName { get; set; }
    
    public string Address { get; set; }
    
    public int OwnerId { get; set; }
    public User Owner { get; set; }
    
    public List<Product> Products { get; set; }
    public List<Transaction> Transactions { get; set; }
}
