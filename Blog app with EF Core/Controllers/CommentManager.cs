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
        public async Task<ActionResult<Comment>> CreateComment(Comment comment)
        {
            var createdComment = await _commentRepository.CreateComment(comment);
            return Ok(createdComment);
        }

        [HttpGet("postId/{postId}")]
        public async Task<ActionResult<List<Comment>>> GetCommentsByPostId(int postId) 
        {
            return Ok(await _commentRepository.GetCommentsByPostId(postId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetCommentById(int id) 
        { 
            return Ok(await _commentRepository.GetCommentById(id));
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Comment>>> GetAllComments()
        {
            return Ok(await _commentRepository.GetAllComments());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Comment>> UpdateComment(int id,Comment comment)
        {
            return Ok(await _commentRepository.UpdateComment(id, comment));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Comment>>> DeleteComment(int id)
        {
            return Ok(await _commentRepository.DeleteComment(id));
        }






    }
}
