using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Learn.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; } // Primary key for Comment

        public int? StockId { get; set; }
        public Stock? Stock { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
