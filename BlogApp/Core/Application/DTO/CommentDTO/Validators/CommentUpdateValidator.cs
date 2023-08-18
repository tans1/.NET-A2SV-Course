using application.Contracts;
using Application.DTO.CommentDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.CommentDTO.Validators
{
    public class CommentUpdateValidator : AbstractValidator<CommentUpdateDTO>
    {
        private readonly IComment _commentRepository;
        public CommentUpdateValidator(IComment comment)
        {
            _commentRepository = comment;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("CommentId is required")
                .GreaterThan(0).WithMessage("CommentId must be greater than 0")
                .NotNull().WithMessage("CommentId is required")
                .MustAsync(async (Id, token) =>
                    {
                        var result = await _commentRepository.Get(Id);
                        return result != null;
                    });

            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("The Comment text is required")
                .NotNull().WithMessage("The Comment text is required");

        }
    }
}
