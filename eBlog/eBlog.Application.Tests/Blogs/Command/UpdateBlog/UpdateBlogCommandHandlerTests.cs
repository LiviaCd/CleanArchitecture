using eBlog.Application.Blogs.Commands.CreateBlog;
using eBlog.Application.Blogs.Commands.UpdateBlog;
using eBlog.Application.DTOs;
using eBlog.Application.Tests.Commun;
using eBlog.Domain.Entity;
using eBlog.Infrastructure.Data;
using eBlog.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Shared.Functions;
using Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Tests.Blogs.Command.UpdateBlog
{
    public class UpdateBlogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateBlogCommandHandler_AllFields_Success()
        {
            // Arrange
            var mockMapper = TestHelper.GetMockMapperVm();

            var handler = new UpdateBlogCommandHandler(
               new BlogRepository(Context),
               new UnitOfWork<BlogDbContext>(Context),
               mockMapper.Object
            );


            var updatedName = "new name";
            var updatedAuthor = "new author";
            var updatedDescription = "new description";
            var updatedImage = "updatedImage.jpg";
            var updatedTextOfBlog = "updated text";

            var blog = await Context.Blogs.FirstOrDefaultAsync(b => b.Id == BlogContextFactory.BlogIdForUpdate);
            Assert.NotNull(blog); 

            Context.Entry(blog).State = EntityState.Detached;

            // Act
            await handler.Handle(new UpdateBlogCommand
            {
                Id = BlogContextFactory.BlogIdForUpdate,
                Name = updatedName,
                Author = updatedAuthor,
                Description = updatedDescription,
                ImageUrl = updatedImage,
                TextOfBlog = updatedTextOfBlog
            }, CancellationToken.None);


            var updatedBlog = await Context.Blogs.SingleOrDefaultAsync(b =>
                b.Id == BlogContextFactory.BlogIdForUpdate &&
                b.Name == updatedName &&
                b.Author == updatedAuthor &&
                b.ImageUrl == updatedImage &&
                b.TextOfBlog == updatedTextOfBlog);

            Assert.NotNull(updatedBlog); 
            Assert.Equal(updatedName, updatedBlog.Name);
            Assert.Equal(updatedAuthor, updatedBlog.Author);
            Assert.Equal(updatedDescription, updatedBlog.Description);
            Assert.Equal(updatedImage, updatedBlog.ImageUrl);
            Assert.Equal(updatedTextOfBlog, updatedBlog.TextOfBlog);
        }

        [Fact]
        public async Task UpdateBlogCommandHandler_Failed()
        {
            // Arrange
            var mockMapper = TestHelper.GetMockMapperVm();

            var handler = new UpdateBlogCommandHandler(
               new BlogRepository(Context),
               new UnitOfWork<BlogDbContext>(Context),
               mockMapper.Object
            );

            var updatedName = "new name";
            var updatedAuthor = "new author";
            var updatedDescription = "new description";
            var updatedImage = "updatedImage.jpg";
            var updatedTextOfBlog = "updated text";

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await handler.Handle(new UpdateBlogCommand
                {
                    Id = BlogContextFactory.BlogIdForFailedUpdate, 
                    Name = updatedName,
                    Author = updatedAuthor,
                    Description = updatedDescription,
                    ImageUrl = updatedImage,
                    TextOfBlog = updatedTextOfBlog
                }, CancellationToken.None);
            });

            // Assert
            Assert.Equal($"Blog with ID {BlogContextFactory.BlogIdForFailedUpdate} not found.", exception.Message);
        }

    }
}
