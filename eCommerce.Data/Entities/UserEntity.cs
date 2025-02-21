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
   public class UserEntity
    {
       
        public int Id { get; set; }
       
        //[RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Email { get; set; }
        //[MinLength(2), MaxLength(50), Required]
        //[RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string FirstName { get; set; }
        //[MinLength(2), MaxLength(50), Required]
        //[RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string LastName { get; set; }
        //[MinLength(1), Required]
        public string Password { get; set; }
        //[ForeignKey(nameof(RoleId)), Required]
        public int RoleId { get; set; }
        public RoleEntity Role { get; set; }
        //[Required]
        public bool Enabled { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<OrderEntity>? Orders { get; set; }
        //[JsonIgnore]
        public ICollection<ProductEntity>? Products { get; set; }
       // public ICollection<CartItem>? CartItems { get; set; }
    }
}
