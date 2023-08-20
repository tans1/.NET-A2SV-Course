using Application.Contracts.Identity;
using Application.DTO.IdentityDTO;
using Application.DTO.IdentityDTO.Validations;
using Application.Exceptions;
using Application.Features.Identity.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Handlers.Commands
{
    public class UpdateUserProfileHandler : IRequestHandler<UpdateProfile, UserDataDTO>
    {
        private readonly IUserService _userService;

        public UpdateUserProfileHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UserDataDTO> Handle(UpdateProfile request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserProfileValidation();
            var validationResult = await validator.ValidateAsync(request.UserData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var result = await _userService.UpdateProfile(request.Id, request.UserData);
            return result;
        }
    }
}
