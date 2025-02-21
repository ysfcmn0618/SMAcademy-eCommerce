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
    public class ProductCommentEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public byte StarCount { get; set; }
        public bool IsConfirmed { get; set; }=false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
