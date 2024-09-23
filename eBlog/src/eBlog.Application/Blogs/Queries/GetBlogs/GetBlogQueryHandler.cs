using AutoMapper;
using eBlog.Application.Abstractions.Queries;
using eBlog.Application.DTOs;
using eBlog.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler(IBlogRepository _blogRepository, IMapper _mapper) : IQueryHandler<GetBlogQuery, List<BlogVm>>
    {
        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAll();

            var blogList = _mapper.Map<List<BlogVm>>(blogs);
            return blogList;
        }
    }
}
