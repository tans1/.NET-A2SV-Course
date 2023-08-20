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
    public class LoginUserHandler : IRequestHandler<LoginUser, AuthResponseDTO>
    {
        private readonly IAuthService _authService;

        public LoginUserHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<AuthResponseDTO> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            var validator = new AuthRequestValidation();
            var result = await validator.ValidateAsync(request.RequestData);

            if (!result.IsValid)
            {
                throw new ValidationException(result);
            }

            var logedUser = await _authService.Login(request.RequestData);
            return logedUser;
        }
    }
}
