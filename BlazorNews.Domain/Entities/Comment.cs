using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorNews.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int NewsId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        public DateTime CreateDate { get; set; } = new DateTime();

        [ForeignKey("NewsId")]
        public News News { get; set; }
    }
}