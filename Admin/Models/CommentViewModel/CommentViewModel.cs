using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models.CommentViewModel
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Text { get; set; }= string.Empty;
        public byte StarCount { get; set; }
        public bool IsConfirmed { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
