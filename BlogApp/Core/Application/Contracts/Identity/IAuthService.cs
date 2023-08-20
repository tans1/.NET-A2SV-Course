using Application.DTO.IdentityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<UserDataDTO> GetUserProfile(string userId);
        Task<AuthResponseDTO> Login(AuthRequestDTO request);
        Task<RegistrationResponseDTO> Register(RegistrationRequestsDTO request);

        Task<bool> Exists(string UserName);
    }
}
