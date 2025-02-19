using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class ProductComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Id { get; set; }
        [ForeignKey(nameof(ProductId)), Required]
        public int ProductId { get; set; }
        [ForeignKey(nameof(UserId)), Required]
        public int UserId { get; set; }
        [MinLength(2), MaxLength(500), Required]
        public string Text { get; set; }
        [MinLength(1), MaxLength(5), Required]
        public byte StarCount { get; set; }
        [Required]
        public bool IsConfirmed { get; set; }=false;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
