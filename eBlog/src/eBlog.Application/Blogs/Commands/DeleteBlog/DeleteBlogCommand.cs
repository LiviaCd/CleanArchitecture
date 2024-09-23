using eBlog.Application.Abstractions.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommand : ICommand<int>
    {
        public int Id { get; set; }
    }
}
