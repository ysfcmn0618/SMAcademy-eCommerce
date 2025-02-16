using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entityes
{
    public class CartItemEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity),Required]
        public int Id { get; set; }
        [ForeignKey(nameof(UserId)),Required]
        public int UserId { get; set; }
        [ForeignKey(nameof(ProductId)), Required]
        public int ProductId { get; set; }
        [MinLength(1), Required]
        public byte Quantity { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
