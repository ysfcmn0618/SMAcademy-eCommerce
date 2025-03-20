﻿namespace App.eCommerce.Models.ViewModels.ProductViewModels
{
    public class MyProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte Stock { get; set; }
        public bool HasDiscount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
