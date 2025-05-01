using eBlog.Application.Abstractions.Commands;
using eBlog.Application.DTOs;
using eBlog.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommand : ICommand<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string TextOfBlog { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public IBrowserFile ImageFile { get; set; }
    }
}
