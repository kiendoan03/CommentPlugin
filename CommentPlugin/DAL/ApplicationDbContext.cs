using CommentPlugin.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CommentPlugin.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
    }
}
