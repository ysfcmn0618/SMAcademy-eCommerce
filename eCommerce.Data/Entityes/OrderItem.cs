using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Data.Entityes
{
    public class OrderItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Id { get; set; }
        [ForeignKey(nameof(OrderId)), Required]
        public int OrderId { get; set; }
        [ForeignKey(nameof(ProductId)), Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [MinLength(1), Required]
        public byte Quantity { get; set; }
        [DataType(DataType.Currency), Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
