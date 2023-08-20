using Application.Contracts.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.IdentityDTO.Validations
{
    public class RegistrationRequestValidation : AbstractValidator<RegistrationRequestsDTO>
    {
        private readonly IAuthService _authService;

        public RegistrationRequestValidation(IAuthService authService)
        {
            _authService = authService;

            Include(new IGenericIdentityValidation());

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .NotNull().WithMessage("FirstName is required")
                .MinimumLength(6).WithMessage("First name length should be more than 6");
                

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("last name is required")
                .NotNull().WithMessage("Last Name is required")
                .MinimumLength(6).WithMessage("Last name length should be more than 6");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required")
                .NotNull().WithMessage("UserName is required")
                .MinimumLength(6).WithMessage("UserName length should be more than 6")
                .MustAsync(async (userName, cancellation) =>
                {
                    var user = await _authService.Exists(userName);
                    return user == false;
                }).WithMessage("UserName already exists")   
                ;
            
        }
    }
}
