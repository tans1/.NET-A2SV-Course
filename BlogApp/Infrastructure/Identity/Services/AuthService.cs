using Application;
using Application.Contracts.Identity;
using Application.DTO.IdentityDTO;
using Application.Exceptions;
using Application.Model.Identity;
using Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
        }


        public async Task<AuthResponseDTO> Login(AuthRequestDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email );
            if ( user == null )
            {
                throw new NotFoundException("User not found with this email, please create new account first");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);
            if (!result.Succeeded)
            {
                throw new BadRequestException("Invalid Username or Password");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthResponseDTO response = new AuthResponseDTO
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }



        public async Task<RegistrationResponseDTO> Register(RegistrationRequestsDTO request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);


            if (existingUser != null)
            {
                throw new BadRequestException("Userr alreay exists");
            }

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail != null)
            {
                throw new BadRequestException("User with this email already exists");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Employee");
                return new RegistrationResponseDTO() { UserId = user.Id };
            }
            else
            {
                throw new Exception($"{result}");
            }
        }




        public async Task<bool> Exists(string Username)
        {
            var user = await _userManager.FindByNameAsync(Username);
            return user != null;
        }




        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
                //new Claim(JwtRegisteredClaimNames.Email, user.Email),
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationsInMinute),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }




        Task<UserDataDTO> IAuthService.GetUserProfile(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
