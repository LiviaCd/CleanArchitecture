using eBlog.Application.Abstractions.Queries;
using eBlog.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Blogs.Queries.GetBlogs
{
    public record GetBlogQuery : IQuery<List<BlogVm>>;
   
}
