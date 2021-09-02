using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlazorNews.Domain.Entities
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }

        public string UserId { get; set; }

        [MaxLength(150)]
        [Display(Name = "عنوان خبر")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]

        public string NewsTitle { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        [MaxLength(100)]
        public string NewsShortDescription { get; set; }

        [Display(Name = "خبر")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public string NewsDescription { get; set; }

        [Display(Name = "فعال است")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public bool IsActive { get; set; }

        public string ImageName { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
