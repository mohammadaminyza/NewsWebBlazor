using BlazorNews.Domain.Entities;
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
