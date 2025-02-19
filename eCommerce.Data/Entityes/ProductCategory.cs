using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entityes
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ProductId)), Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(CategoryId)), Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
