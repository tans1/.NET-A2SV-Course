

using FluentValidation;

namespace Application.DTO.PostDTO.Validators
{
    public class IPostValidator : AbstractValidator<IPostBaseDTO>
    {
        public IPostValidator()
        {
            RuleFor(X => X.Title)
                .NotEmpty().WithMessage("Post Title is required")
                .NotNull().WithMessage("Post Title is required");

            RuleFor(X => X.Content)
                .NotEmpty().WithMessage("Post Content is required")
                .NotNull().WithMessage("Post Content is required");
        }
    }
}
