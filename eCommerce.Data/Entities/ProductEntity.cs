using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class ProductEntity
    {       

        public int Id { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Details { get; set; }

        public ushort StockAmount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool Enabled { get; set; } = true;

        //public UserEntity Seller { get; set; }
        //public CategoryEntity Category { get; set; }
        public ICollection<ProductImageEntity> ?ProductImages { get; set; }
        public ICollection<ProductCommentEntity> ?ProductComments { get; set; }
        public ICollection<ProductCategoryEntity> ?ProductCategories { get; set; }
    }
}
