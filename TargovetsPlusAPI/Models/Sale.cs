namespace TargovetsPlusAPI.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } // Navigation property

        public int ProductId { get; set; }
        public Product Product { get; set; } // Navigation property

        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}