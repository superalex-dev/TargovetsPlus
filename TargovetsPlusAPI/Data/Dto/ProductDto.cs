namespace TargovetsPlusAPI.Data.Dto;

public class ProductDto
{
    public string ProductName { get; set; }

    public string Category { get; set; }

    public decimal Price { get; set; }

    public string Barcode { get; set; }

    public int StockQuantity { get; set; }
}