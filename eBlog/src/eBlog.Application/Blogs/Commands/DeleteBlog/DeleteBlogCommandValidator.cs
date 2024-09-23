using eBlog.Application.Blogs.Commands.CreateBlog;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandValidator : AbstractValidator<DeleteBlogCommand>
    {
        public DeleteBlogCommandValidator() 
        {
            RuleFor(command => command.Id)
                .NotEmpty().GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
