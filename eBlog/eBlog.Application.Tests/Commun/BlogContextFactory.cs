using eBlog.Domain.Entity;
using eBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Tests.Commun
{
    public class BlogContextFactory
    {
        public static int BlogIdForDelete = 1;
        public static int BlogIdForFailedDelete = 101;
        public static int BlogIdForUpdate = 2;
        public static int BlogIdForFailedUpdate = 203;

        public static BlogDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new BlogDbContext(options);
            context.Database.EnsureCreated();

            context.Blogs.AddRange(
                new Blog {
                    Id = BlogIdForDelete, 
                    Name = "BlogToDelete", 
                    Author = "Author",
                    Description = "Test Description", 
                    ImageUrl = "testimageurl.jpg",    
                    TextOfBlog = "This is the content of the blog", 
                    DateCreated = DateTime.UtcNow
                },
                new Blog { 
                    Id = 2, 
                    Name = "AnotherBlog", 
                    Author = "Other",
                    Description = "Test Description", 
                    ImageUrl = "testimageurl.jpg",   
                    TextOfBlog = "This is the content of the blog", 
                    DateCreated = DateTime.UtcNow
                }
            );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(BlogDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }

}
