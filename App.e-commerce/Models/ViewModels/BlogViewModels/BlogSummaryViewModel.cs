﻿namespace App.eCommerce.Models.ViewModels.BlogViewModels
{
    public class BlogSummaryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string SummaryContent { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public int CommentCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
