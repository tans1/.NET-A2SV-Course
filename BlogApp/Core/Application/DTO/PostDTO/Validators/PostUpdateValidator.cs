using FluentValidation;
using application;
using application.Contracts;

namespace Application.DTO.PostDTO.Validators
{
    public class PostUpdateValidator : AbstractValidator<PostUpdateDTO>
    {
        private readonly IPost _postRepository;
        public PostUpdateValidator(IPost postRepository)
        {
            _postRepository = postRepository;

            Include(new IPostValidator());

            RuleFor(X => X.Id)
                .NotEmpty().WithMessage("Post Id is required")
                .NotNull().WithMessage("Post Id is required")
                .LessThan(0).WithMessage("Post Id must be greater than 0")
                .MustAsync(async (Id, token) =>
                {
                    var result = await _postRepository.Get(Id);
                    return result != null;
                });

            //RuleFor(X => X.Title)
            //    .NotEmpty().WithMessage("Post Title is required")
            //    .NotNull().WithMessage("Post Title is required");

            //RuleFor(X => X.Content)
            //    .NotEmpty().WithMessage("Post Content is required")
            //    .NotNull().WithMessage("Post Content is required");

        }
    }
}
