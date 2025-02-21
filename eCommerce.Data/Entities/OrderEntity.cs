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
    public class OrderEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string OrderCode { get; set; }

        public string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<OrderItemEntity> OrderItems { get; set; }
    }
}
