namespace TargovetsPlusAPI.Models;

public class Alert
{
    public int Id { get; set; }
    
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
    
    public string AlertType { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime CreatedDate { get; set; }
}