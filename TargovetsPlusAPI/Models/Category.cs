﻿namespace TargovetsPlusAPI.Models;

public class Category
{
    public int Id { get; set; }
    
    public string CategoryName { get; set; }
    
    public ICollection<Product> Products { get; set; }
}