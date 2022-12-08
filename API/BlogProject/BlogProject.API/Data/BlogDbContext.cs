using BlogProject.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.API.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        //DBSet
        public DbSet<Post> Posts{get; set;}
    }
}
