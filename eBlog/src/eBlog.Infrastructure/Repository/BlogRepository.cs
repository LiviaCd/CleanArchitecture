using eBlog.Domain.Entity;
using eBlog.Domain.Repository;
using eBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Infrastructure.Repository
{
    public class BlogRepository(BlogDbContext context) : RepositoryBase<Blog, BlogDbContext>(context), IBlogRepository
    {
        /*
        private readonly BlogDbContext _blogDbContext;
        public BlogRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            await _blogDbContext.Blogs.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteBlogAsync(int id)
        {
            return await _blogDbContext.Blogs
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _blogDbContext.Blogs.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id);
        }

        public async Task<int> UpdateBlogAsync(Blog blog)
        {
           
            _blogDbContext.Set<Blog>().Update(blog);
            return blog.Id;    
        }
        */
    }   
}
