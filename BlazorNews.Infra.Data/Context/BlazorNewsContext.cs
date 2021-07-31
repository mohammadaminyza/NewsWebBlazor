using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorNews.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorNews.Infra.Data.Context
{
    public class BlazorNewsContext : DbContext
    {
        public BlazorNewsContext(DbContextOptions<BlazorNewsContext> options) : base(options)
        {

        }

        public DbSet<News> Newses { get; set; }
    }
}
