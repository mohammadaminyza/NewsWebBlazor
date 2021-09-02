using BlazorNews.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorNews.Infra.Data.Context
{
    public class BlazorNewsContext : IdentityDbContext
    {
        public BlazorNewsContext(DbContextOptions<BlazorNewsContext> options) : base(options)
        {

        }

        public DbSet<News> Newses { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
