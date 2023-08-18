using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.PostDTO.Validators
{
    public class PostCreateValidator : AbstractValidator<PostCreateDTO>
    {
        public PostCreateValidator()
        {
            Include(new IPostValidator());

            //RuleFor(X => X.Title)
            //    .NotEmpty().WithMessage("Post Title is required")
            //    .NotNull().WithMessage("Post Title is required");

            //RuleFor(X => X.Content)
            //    .NotEmpty().WithMessage("Post Content is required")
            //    .NotNull().WithMessage("Post Content is required");
        }
    }
}
