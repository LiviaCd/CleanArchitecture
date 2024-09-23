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

namespace eBlog.Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler(IBlogRepository _blogRepository, IMapper _mapper) : IQueryHandler<GetBlogByIdQuery, BlogVm>
    {
        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetById(request.BlogId);
            return _mapper.Map<BlogVm>(blog);
        }
    }
}
