using AutoMapper;
using eBlog.Application.Blogs.Commands.CreateBlog;
using eBlog.Application.Blogs.Commands.DeleteBlog;
using eBlog.Application.DTOs;
using eBlog.Application.Tests.Commun;
using eBlog.Domain.Entity;
using eBlog.Domain.Repository;
using eBlog.Infrastructure.Data;
using eBlog.Infrastructure.Repository;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shared.Functions;
using Shared.UnitOfWork;

namespace eBlog.Application.Tests.Blogs.Command.CreateBlog
{
    public class CreateBlogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateBlogCommandHandler_Success()
        {
            // Arrange
            var sampleBlog = new Blog
            {
                Name = "AnotherBlog1234",
                Author = "Other",
                Description = "Test Description",
                ImageUrl = "testimageurl.jpg",
                TextOfBlog = "This is the content of the blog",
                DateCreated = DateTime.UtcNow
            };

            var mockMapper = TestHelper.GetMockMapper(sampleBlog);
            var mockEnv = TestHelper.GetMockWebHostEnvironment();
            var addPhoto = TestHelper.GetAddPhotoHelper(mockEnv);

            var handler = new CreateBlogCommandHandler(
                mockMapper.Object,
                new BlogRepository(Context),
                new UnitOfWork<BlogDbContext>(Context),
                addPhoto);

            // Act
            var result = await handler.Handle(new CreateBlogCommand
            {
                Name = sampleBlog.Name,
                Author = sampleBlog.Author,
                Description = sampleBlog.Description,
                ImageUrl = sampleBlog.ImageUrl,
                TextOfBlog = sampleBlog.TextOfBlog,
                DateCreated = sampleBlog.DateCreated
            }, CancellationToken.None);

            // Assert 

            Assert.NotNull(
                await Context.Blogs.SingleOrDefaultAsync(b =>
                    b.Id > 0 && b.Name == sampleBlog.Name &&
                    b.Author == sampleBlog.Author &&
                    b.Description == sampleBlog.Description &&
                    b.ImageUrl == sampleBlog.ImageUrl &&
                    b.TextOfBlog == sampleBlog.TextOfBlog &&
                    b.DateCreated == sampleBlog.DateCreated));
        }
    }

}
