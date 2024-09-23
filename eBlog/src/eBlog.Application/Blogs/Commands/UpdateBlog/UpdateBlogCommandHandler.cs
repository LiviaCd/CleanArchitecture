using AutoMapper;
using eBlog.Application.Abstractions.Commands;
using eBlog.Application.DTOs;
using eBlog.Domain.Entity;
using eBlog.Domain.Repository;
using MediatR;
using Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Blogs.Commands.UpdateBlog
{
    
    public class UpdateBlogCommandHandler(IBlogRepository _blogRepository, IUnitOfWork _unitOfWork, IMapper _mapper) : ICommandHandler<UpdateBlogCommand, int>
    {
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogToUpdate = _mapper.Map<Blog>(request.Item);
            await _blogRepository.Update(blogToUpdate);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return blogToUpdate.Id;
        }
    }
}
