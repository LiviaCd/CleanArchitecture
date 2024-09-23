using eBlog.Application.Abstractions.Commands;
using eBlog.Application.DTOs;
using eBlog.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommand : ICommand<int>
    {
        public BlogVm Item {  get; set; }
        public UpdateBlogCommand(BlogVm item)
        {
            Item = item;
        }
    }
}
