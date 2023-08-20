using Application.Contracts.Identity;
using Application.DTO.Custom;
using Application.DTO.IdentityDTO.Validations;
using Application.Exceptions;
using Application.Features.Identity.Requests.Commands;
using MediatR;


namespace Application.Features.Identity.Handlers.Commands
{
    public class ChangePasswordHandler : IRequestHandler<ChangePassword, CustomResponseDTO>
    {
        private readonly IUserService _userService;

        public ChangePasswordHandler(IUserService userService)
            {
            _userService = userService;
        }

        public async Task<CustomResponseDTO> Handle(ChangePassword request, CancellationToken cancellationToken)
        {
            var validator = new ChangePasswordValidation();
            var validationResult = await validator.ValidateAsync(request.changePasswordData);

            if (!validationResult.IsValid) 
            {
                throw new ValidationException(validationResult);
            }

            var result = await _userService.ChangePassword(request.UserId, request.changePasswordData);
            if (result == true)
            {
                return new CustomResponseDTO(){
                    Success = "True",
                    Message = "Successfully changed the password"
                };
            }
            else
            {
                return new CustomResponseDTO(){
                    Success = "False",
                    Message = "Not Successfully changed the password"
                };
            }
        }
    }
}
