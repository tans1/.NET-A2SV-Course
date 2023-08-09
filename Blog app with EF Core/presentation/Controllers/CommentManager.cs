using Blog_app_with_EF_Core.application;
using Blog_app_with_EF_Core.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog_app_with_EF_Core.Controllers
{
    [Route("comment")]
    [ApiController]
    public class CommentManager : ControllerBase
    {
        private readonly IBlogComment _commentRepository;
        public CommentManager(IBlogComment commentReposirtory) 
        {
            _commentRepository = commentReposirtory;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Comment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            var createdComment = await _commentRepository.CreateComment(comment);
            if (createdComment != null)
            {
                return Ok(createdComment);
            }
            else {
                return BadRequest($"Sorry, comment is not created {createdComment}");
            }
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Comment>>> GetAllComments()
        {
            return Ok(await _commentRepository.GetAllComments());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Comment))]
        public async Task<IActionResult> GetCommentById(int id) 
        { 
            var comment = await _commentRepository.GetCommentById(id);
            if (comment == null){
                return NotFound("Sorry, comment doesn't exist with this Id");
            }
            return Ok(comment);
        }


        [HttpGet("postId/{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Comment>>> GetCommentsByPostId(int postId) 
        {
            var comments = await _commentRepository.GetCommentsByPostId(postId);
            if (comments == null){
                return NotFound("Sorry, comments doesn't exist with this PostId");
            }
            return Ok(comments);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Comment>> UpdateComment(int id,Comment comment)
        {
            var result = await _commentRepository.UpdateComment(id, comment);
            if (result == null){
                return BadRequest("Sorry, comment with this Id is not found to be updated");
            }
            return Ok(result);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Comment>>> DeleteComment(int id)
        {
            var result = await _commentRepository.DeleteComment(id);
            if (result == null){
                return NotFound("Sorry, comment with this Id is not found to be deleted");
            }
            return Ok(result);
        }
    }
}
