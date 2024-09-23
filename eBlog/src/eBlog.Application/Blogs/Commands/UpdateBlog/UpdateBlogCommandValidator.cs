using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator() 
        {
            RuleFor(v => v.Item.Name)
               .NotEmpty().WithMessage("Name is required")
               .MaximumLength(200).WithMessage("Name must not exceed 200 characters");
            RuleFor(v => v.Item.Description)
                .NotEmpty().WithMessage("Description is required");
            RuleFor(v => v.Item.Author)
                .NotEmpty().WithMessage("Author is required")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters");
            RuleFor(v => v.Item.TextOfBlog)
                .NotEmpty().WithMessage("Text is required");
            RuleFor(v => v.Item.DateCreated)
                .Must(date => date != default(DateTime))
                .WithMessage("DateCreated must be a valid date.");
        }
    }
}
