using AutoMapper;
using eBlog.Application.Abstractions.Commands;
using eBlog.Application.DTOs;
using eBlog.Domain.Entity;
using eBlog.Domain.Repository;
using MediatR;
using Shared.Functions;
using Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AddPhoto _addPhoto;

        public CreateBlogCommandHandler(
            IMapper mapper,
            IBlogRepository blogRepository,
            IUnitOfWork unitOfWork,
            AddPhoto addPhoto)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
            _addPhoto = addPhoto;
        }

        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogVm = new BlogVm
            {
                Name = request.Name,
                Author = request.Author,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                TextOfBlog = request.TextOfBlog,
                DateCreated = request.DateCreated,
                ImageFile = request.ImageFile
            };
           
            var blogEntity = _mapper.Map<Blog>(blogVm);

            if (blogVm.ImageFile != null)
            {
                blogEntity.ImageUrl = await _addPhoto.AddPhotoToEntityAsync(blogVm.ImageFile);
            }

            var resultBlog = await _blogRepository.Add(blogEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BlogVm>(resultBlog);
        }
       
    }
}
