using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.IdentityDTO.Validations
{
    public class ChangePasswordValidation : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordValidation()
        {
            RuleFor(x => x.PreviousPassword)
                .NotEmpty().WithMessage("Previous password is required")
                .MinimumLength(6).WithMessage("Previous password length should be more than 6");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password is required")
                .MinimumLength(6).WithMessage("New password length should be more than 6");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm password is required")
                .MinimumLength(6).WithMessage("Confirm password length should be more than 6")
                .Equal(x => x.NewPassword).WithMessage("Confirm password should be equal to new password");
        }
    }
}
