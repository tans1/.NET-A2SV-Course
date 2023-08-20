using Application.DTO.IdentityDTO;
using MediatR;

namespace Application.Features.Identity.Requests.Requests
{
    public class GetUserProfile : IRequest<UserDataDTO>
    {
        public string UserId { get; set; }

    }
}
