using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Domain.Entities;

namespace BlazorNews.Domain.Entities
{
    public class User
    {
        [Key] 
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public IEnumerable<News> Newses { get; set; }
    }
}
