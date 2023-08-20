using Application.Contracts.Identity;
using Application.DTO.IdentityDTO;
using Application.DTO.IdentityDTO.Validations;
using Application.Exceptions;
using Application.Features.Identity.Requests.Commands;
using MediatR;


namespace Application.Features.Identity.Handlers.Commands
{
    public class RegisterUserHandler : IRequestHandler<RegisterUser, RegistrationResponseDTO>
    {
        private readonly IAuthService _authService;

        public RegisterUserHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<RegistrationResponseDTO> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            var validator = new RegistrationRequestValidation(_authService);
            var validationResult = await validator.ValidateAsync(request.RequestData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var registedUser = await _authService.Register(request.RequestData);

            return registedUser;            
        }
    }
}
