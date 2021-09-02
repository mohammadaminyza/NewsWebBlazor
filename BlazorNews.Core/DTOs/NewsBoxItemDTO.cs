using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorNews.Core.DTOs
{
    public class NewsBoxItemDTO
    {
        public int NewsId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0} نمیتواند از {1} بیشتر باشد")]
        [Display(Name = "عنوان خبر")]
        public string NewsTitle { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند از {1} بیشتر باشد")]
        public string NewsShortDescription { get; set; }

        [Display(Name = "خبر اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NewsDescription { get; set; }

        [Display(Name = "فعال / غیر فعال")]
        public bool IsActive { get; set; }

        [Display(Name = "تصویر خبر")]
        public string ImageName { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; } =DateTime.Now;
    }
}
