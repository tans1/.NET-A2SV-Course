using Application.Contracts.Identity;
using Application.DTO.IdentityDTO;
using Application.Exceptions;
using Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using System.IdentityModel.Tokens.Jwt;


namespace Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> ChangePassword(string Id, ChangePasswordDTO changePasswordData)
        {
            var user = await _userManager.FindByIdAsync(Id);

            await _userManager.ChangePasswordAsync(user, changePasswordData.PreviousPassword, changePasswordData.NewPassword);

            return true;
        }


       


        public async Task<UserDataDTO?> GetProfile(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            var userProfile = new UserDataDTO()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };
            return userProfile;

        }

        public async Task<UserDataDTO> UpdateProfile(string Id, UpdateUserProfileDTO userData)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(Id);

                if (user == null)
                {
                    throw new Exception();
                }

                user.FirstName = userData.FirstName;
                user.LastName = userData.LastName;
                await _userManager.UpdateAsync(user);
                return await GetProfile(Id);
            }
            catch(Exception ex)
            {
                throw new BadRequestException("Not able to create User");
            }
        }

    }
}
