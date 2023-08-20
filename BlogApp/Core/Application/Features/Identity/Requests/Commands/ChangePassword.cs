using Application.DTO.Custom;
using Application.DTO.IdentityDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Requests.Commands
{
    public class ChangePassword : IRequest<CustomResponseDTO>
    {
        public string UserId { get; set; }
        public ChangePasswordDTO changePasswordData { get; set; }
    }
}
