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
        
    }   
}
