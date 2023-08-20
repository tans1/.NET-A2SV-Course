using Application.Contracts.Identity;
using Application.DTO.Custom;
using Application.DTO.IdentityDTO;
using Application.Features.Identity.Requests.Commands;
using Application.Features.Identity.Requests.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{
    [Route("user")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] AuthRequestDTO requestData)
        {

            var result = await _mediator.Send(new LoginUser{ RequestData = requestData });
            return Ok(result);
        }



        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponseDTO>> Register([FromBody] RegistrationRequestsDTO requestData)
        {
            var result = await _mediator.Send(new RegisterUser { RequestData = requestData });
            return Ok(result);
        }


        [HttpGet("profile")]
        [Authorize]
        public async Task<ActionResult<UserDataDTO>> Profile()
        {
            var UserId = GetCurrentUserId();

            var result = await _mediator.Send(new GetUserProfile { UserId = UserId });
            return Ok(result);
        }


        [HttpPost("update")]
        [Authorize]
        public async Task<ActionResult<RegistrationResponseDTO>> Update([FromBody] UpdateUserProfileDTO requestData)
        {
            var UserId = GetCurrentUserId();

            var result = await _mediator.Send(new UpdateProfile { Id = UserId, UserData = requestData });
            return Ok(result);
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<ActionResult<CustomResponseDTO>> ChangePassword([FromBody] ChangePasswordDTO requestData)
        {
            var UserId = GetCurrentUserId();

            var result = await _mediator.Send(new ChangePassword {UserId = UserId, changePasswordData = requestData });
            return Ok(result);
        }


        private string GetCurrentUserId()
        {
            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);
            var payload = jwtToken.Payload;
            string userId = payload["uid"]?.ToString();

            return userId;
        }
        
    }
}
