using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.IdentityDTO.Validations
{
    public class UpdateUserProfileValidation : AbstractValidator<UpdateUserProfileDTO>
    {
        public UpdateUserProfileValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.")
                .MinimumLength(6)
                .WithMessage("First name can't be shorter than 6 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .MinimumLength(6)
                .WithMessage("Last name can't be shorter than 6 characters.");
        }
    }
}
