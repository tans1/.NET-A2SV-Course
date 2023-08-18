using Application.DTO.CommentDTO;
using Application.Features.Comments.Requests.Commands;
using Application.Features.Comments.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("comment")]
    public class CommentAPI : Controller
    {
        private readonly IMediator _mediator;
        public CommentAPI(IMediator mediator)
        {
            _mediator = mediator;
            
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<CommentResponseDTO>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllComment());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentResponseDTO>> GetSingle(int id)
        {
            var result = await _mediator.Send(new GetSingleComment { Id = id });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<CommentResponseDTO>> Create([FromBody] CommentCreateDTO commentData)
        {
            var result = await _mediator.Send(new CreateComment{commentData = commentData});
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] CommentUpdateDTO updateData)
        {
            var result = await _mediator.Send(new UpdateComment {updateData = updateData});
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteComment {Id = id});
            return Ok(result);
        }
    }
}
