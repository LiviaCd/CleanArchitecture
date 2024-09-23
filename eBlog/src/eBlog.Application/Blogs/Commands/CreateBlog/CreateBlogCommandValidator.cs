using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters");
            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required");
            RuleFor(v => v.Author)
                .NotEmpty().WithMessage("Author is required")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters");
            RuleFor(v => v.TextOfBlog)
                .NotEmpty().WithMessage("Text is required");
            RuleFor(v => v.DateCreated)
                .Must(date => date != default(DateTime))
                .WithMessage("DateCreated must be a valid date.");
            RuleFor(v => v.ImageUrl)
                .NotEmpty().WithMessage("Image is required");
        }
    }
}
