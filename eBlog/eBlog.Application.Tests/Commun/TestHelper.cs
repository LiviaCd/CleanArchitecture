using AutoMapper;
using eBlog.Application.DTOs;
using eBlog.Domain.Entity;
using Microsoft.AspNetCore.Hosting;
using Moq;
using Shared.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Tests.Commun
{
    public static class TestHelper
    {
        public static Mock<IMapper> GetMockMapper(Blog sampleBlog)
        {
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(m => m.Map<Blog>(It.IsAny<BlogVm>())).Returns(sampleBlog);
            mockMapper.Setup(m => m.Map<BlogVm>(It.IsAny<Blog>())).Returns(new BlogVm
            {
                Name = sampleBlog.Name,
                Author = sampleBlog.Author,
                Description = sampleBlog.Description,
                ImageUrl = sampleBlog.ImageUrl,
                TextOfBlog = sampleBlog.TextOfBlog,
                DateCreated = sampleBlog.DateCreated
            });

            return mockMapper;
        }

        public static Mock<IMapper> GetMockMapperVm()
        {
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(m => m.Map<Blog>(It.IsAny<BlogVm>())).Returns((BlogVm vm) => new Blog
            {
                Id = vm.Id,
                Name = vm.Name,
                Author = vm.Author,
                Description = vm.Description,
                ImageUrl = vm.ImageUrl,
                TextOfBlog = vm.TextOfBlog,
                DateCreated = vm.DateCreated
            });

            mockMapper.Setup(m => m.Map<BlogVm>(It.IsAny<Blog>())).Returns((Blog b) => new BlogVm
            {
                Id = b.Id,
                Name = b.Name,
                Author = b.Author,
                Description = b.Description,
                ImageUrl = b.ImageUrl,
                TextOfBlog = b.TextOfBlog,
                DateCreated = b.DateCreated
            });

            return mockMapper;
        }


        public static Mock<IWebHostEnvironment> GetMockWebHostEnvironment(string rootPath = "wwwroot")
        {
            var mockEnv = new Mock<IWebHostEnvironment>();
            mockEnv.Setup(e => e.WebRootPath).Returns(rootPath);
            return mockEnv;
        }

        public static AddPhoto GetAddPhotoHelper(Mock<IWebHostEnvironment> mockEnv)
        {
            return new AddPhoto(mockEnv.Object);
        }
    }
}
