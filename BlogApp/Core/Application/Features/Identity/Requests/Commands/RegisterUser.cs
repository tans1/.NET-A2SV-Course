using Application.DTO.IdentityDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.Requests.Commands
{
    public class RegisterUser : IRequest<RegistrationResponseDTO>
    {
        public RegistrationRequestsDTO RequestData { get; set; }
    }
}
