using eBlog.Application.Blogs.Commands.DeleteBlog;
using eBlog.Application.Tests.Commun;
using eBlog.Domain.Repository;
using eBlog.Infrastructure.Data;
using eBlog.Infrastructure.Repository;
using Moq;
using Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Tests.Blogs.Command.DeleteBlog
{
    public class DeleteBlogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteBlogCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteBlogCommandHandler(
                new BlogRepository(Context),
                new UnitOfWork<BlogDbContext>(Context));

            // Act
            var result = await handler.Handle(new DeleteBlogCommand
            {
                Id = BlogContextFactory.BlogIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Blogs.SingleOrDefault(b => b.Id == BlogContextFactory.BlogIdForDelete));
        }

        [Fact]
        public async Task DeleteBlogCommandHandler_FailOnNotFound()
        {
            // Arrange
            var handler = new DeleteBlogCommandHandler(
            new BlogRepository(Context),
            new UnitOfWork<BlogDbContext>(Context));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await handler.Handle(new DeleteBlogCommand { Id = BlogContextFactory.BlogIdForFailedDelete }, CancellationToken.None));

            Assert.Equal("Entity not found", exception.Message);
        }
    }
}
