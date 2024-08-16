namespace TargovetsPlusAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } // Alcohol, Tobacco, etc.
        public DateTime ExpiryDate { get; set; }

        // Navigation property for related sales
        public ICollection<Sale> Sales { get; set; }
    }
}