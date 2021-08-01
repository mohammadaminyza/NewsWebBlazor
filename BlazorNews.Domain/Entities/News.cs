using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Domain.Entities;

namespace BlazorNews.Domain.Entities
{
    public class News
    {
        [Key]
        public Guid NewsId { get; set; } = Guid.NewGuid();

        public int UserId { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "عنوان خبر")]
        public string NewsTitle { get; set; }

        [Required]
        [MaxLength(100)]
        public string NewsShortDescription { get; set; }

        [Required]
        public string NewsDescription { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public string ImageName { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
