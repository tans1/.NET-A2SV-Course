using Application.Contracts.Identity;
using Application.DTO.IdentityDTO;
using Application.Exceptions;
using Application.Features.Identity.Requests.Requests;
using MediatR;


namespace Application.Features.Identity.Handlers.Requests
{
    public class GetUserProfileHandler : IRequestHandler<GetUserProfile, UserDataDTO>
    {
        private readonly IUserService _userService;

        public GetUserProfileHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UserDataDTO> Handle(GetUserProfile request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetProfile(request.UserId);

            if (user == null) {
                throw new NotFoundException("User Not Found");
            }
            return user;
        }
    }
}
