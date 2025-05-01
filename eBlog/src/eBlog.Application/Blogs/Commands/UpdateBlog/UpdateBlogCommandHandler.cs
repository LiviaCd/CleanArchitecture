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
            var existingBlog = await _blogRepository.GetById(request.Id);
            if (existingBlog == null)
            {
                throw new InvalidOperationException($"Blog with ID {request.Id} not found.");
            }

            existingBlog.Name = request.Name;
            existingBlog.Author = request.Author;
            existingBlog.Description = request.Description;
            existingBlog.ImageUrl = request.ImageUrl;
            existingBlog.TextOfBlog = request.TextOfBlog;
            existingBlog.DateCreated = request.DateCreated;

            await _blogRepository.Update(existingBlog);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return existingBlog.Id;
        }

    }
}
