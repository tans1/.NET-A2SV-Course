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
        public async Task<IActionResult> CreatePost(Post post)
        {
            return Ok(await _repository.CreatePost(post));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok(await _repository.GetAllPosts());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetSinglePost(int id)
        {
            var post = await _repository.GetPostbyId(id);
            if (post == null)
                return NotFound("Sorry, post doesn't exist");
            return Ok(post);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> UpdatePost(int id, Post post)
        {
            var newPost = await _repository.UpdatePost(id, post);

            if (newPost == null)
                return NotFound("POST not found, to update");
            return Ok(newPost);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _repository.DeletePost(id);
            if (post == null)
                return NotFound("post not found to delete");
            return Ok(post);
        }
    }
}
