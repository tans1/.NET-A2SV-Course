using Microsoft.AspNetCore.Mvc;
using Blog_app_with_EF_Core.data;
using Blog_app_with_EF_Core.model;

namespace Blog_app_with_EF_Core.controller
{
    [Route("")]
    [ApiController]
    public class PostManager : ControllerBase
    {
        private readonly BlogDbContext  _database;
        public PostManager(BlogDbContext database) 
        {
            _database = database;
        }

        // create
        [HttpPost("create")]
        public async Task<IActionResult> CreatePost() 
        {
                var post = new Post();
                post.Title = "post1";
                post.Content = "content1";
                post.CreatedAt = DateTime.Now;

                _database.Posts.Add(post); 
                await _database.SaveChangesAsync();
                
                return Ok("Created successgully");
        } 

        // read
        [HttpGet("getall")]
        public List<Post> GetAllPosts() 
        {


            var posts =  _database.Posts.ToList();

            return posts;
        }

        [HttpGet("getsingle/:id")]
        public Post GetPostbyId(int id)
        {
            var post = _database.Posts.Find(id);
            if (post != null){
                return post;
            }
            return null;
        }
        

        [HttpPut("update")]
        public void UpdatePost(int id) 
        {
            var post = _database.Posts.Find(id);

            if (post != null){
                post.Title = "post2";
                post.Content = "content3";
                post.CreatedAt = DateTime.Now;

                _database.Posts.Update(post);
                _database.SaveChanges();

                Console.WriteLine("updated succefully");
            }
            
        }

        [HttpPost("delete")]
        public void DeletePost(int id) 
        {
            var post = _database.Posts.Find(id);

            if (post != null){
                _database.Posts.Remove(post);
                _database.SaveChanges();
                Console.WriteLine("deleted succefully");
            }
            
        }
    }

}
