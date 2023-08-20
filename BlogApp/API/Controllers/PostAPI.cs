using Application.DTO.PostDTO;
using Application.Features.Posts.Requests.Commands;
using Application.Features.Posts.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{

    [ApiController]
    [Route("post")]
    public class PostAPI : Controller
    {
        private readonly IMediator _mediator;

        public PostAPI(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<PostResponseDTO>>> GetAll()
        {
            // getting the user id from the token
            // you can Get the User Id from the authenticated user any place in the application from the HttpContext

            string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);
            var payload = jwtToken.Payload;
            string userId = payload["uid"]?.ToString();



            var result = await _mediator.Send(new GetAllPosts());
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostResponseDTO>> GetSingle(int id)
        {
            var result = await _mediator.Send(new GetSinglePost { Id = id });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<PostResponseDTO>> Create([FromBody] PostCreateDTO postData)
        {
            var result = await _mediator.Send(new CreatePost {postData = postData});
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] PostUpdateDTO updateData)
        {
            var result = await _mediator.Send(new UpdatePost {updateData = updateData});
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePost {Id = id});
            return Ok(result);
        }
    }
}
