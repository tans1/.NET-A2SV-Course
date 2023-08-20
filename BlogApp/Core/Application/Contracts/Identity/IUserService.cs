using Application.DTO.IdentityDTO;
using Microsoft.AspNetCore.Identity;


namespace Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<UserDataDTO?> GetProfile(string Id);

        Task<UserDataDTO?> UpdateProfile(string Id, UpdateUserProfileDTO userData);

        Task<bool> ChangePassword(string Id, ChangePasswordDTO changePasswordDTO);

        

    }
}
