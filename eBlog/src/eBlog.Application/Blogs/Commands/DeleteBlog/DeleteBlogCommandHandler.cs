using eBlog.Application.Abstractions.Commands;
using eBlog.Domain.Repository;
using MediatR;
using Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler(IBlogRepository _blogRepository, IUnitOfWork _unitOfWork) : ICommandHandler<DeleteBlogCommand, int>
    {
        public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            await _blogRepository.Delete(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}
