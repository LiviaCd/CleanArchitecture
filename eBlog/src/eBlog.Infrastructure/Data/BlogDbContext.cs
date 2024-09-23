using eBlog.Domain.Entity;
using eBlog.Infrastructure.Data.Configuration.DBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Infrastructure.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions) : base(dbContextOptions) 
        { } 
        
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BlogsConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
        }
        */
    }
}
