using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.CommentDTO.Validators
{
    public class CommentCreateValidator : AbstractValidator<CommentCreateDTO>
    {
        public CommentCreateValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("PostId is required, because the comments is given for posts only")
                .GreaterThan(0).WithMessage("PostId must be greater than 0")
                .NotNull().WithMessage("PostId is required, because the comments is given for posts only");

            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("The Comment text is required")
                .NotNull().WithMessage("The Comment text is required");


        }
    }
}
