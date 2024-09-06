namespace TargovetsPlusAPI.Models;

public class Notification
{
    public int Id { get; set; }
    
    public DateTime NotificationDate { get; set; }
    
    public string NotificationType { get; set; }
    
    public string SentTo { get; set; }
    
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
    
    public int ShopId { get; set; }
    public Shop Shop { get; set; }
}