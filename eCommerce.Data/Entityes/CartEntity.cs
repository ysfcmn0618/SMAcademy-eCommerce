using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entityes
{
    public class CartEntity
    {
        public int Id { get; set; }
        public ICollection<CartItemEntity> Items { get; set; }
    }
}
