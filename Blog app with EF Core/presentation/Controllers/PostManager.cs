using Blog_app_with_EF_Core.application;
using Blog_app_with_EF_Core.model;
using Blog_app_with_EF_Core.repository;
using Microsoft.AspNetCore.Mvc;

namespace Blog_app_with_EF_Core.Controllers
{
    [Route("post")]
    [ApiController]
    public class PostManager : ControllerBase
    {
        private readonly IBlogPost _repository;

        public PostManager(IBlogPost PostRepository)
        {
            _repository = PostRepository;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post))]
        public async Task<IActionResult> CreatePost(Post post)
        {
            var result = await _repository.CreatePost(post);
            if (result == null){
                return BadRequest("Sorry, post not created");
            }
            return Ok(result);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Post>))]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok(await _repository.GetAllPosts());

        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Post))]
        public async Task<IActionResult> GetSinglePost(int id)
        {
            var post = await _repository.GetPostbyId(id);
            if (post == null)
                return NotFound("Sorry, post doesn't exist with this Id");
            return Ok(post);
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Post))]
        public async Task<IActionResult> UpdatePost(int id, Post post)
        {
            var newPost = await _repository.UpdatePost(id, post);

            if (newPost == null)
                return NotFound("POST not found, to be updated");
            return Ok(newPost);
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(IEnumerable<Post>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _repository.DeletePost(id);
            if (post == null)
                return NotFound("POST with this Id, not found to be delete");
            return Ok(post);
        }
    }
}
