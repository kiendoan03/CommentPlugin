using CommentPlugin_v2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CommentPlugin_v2.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
    }
}
