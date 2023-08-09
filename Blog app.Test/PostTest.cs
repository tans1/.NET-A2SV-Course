using Blog_app_with_EF_Core.data;
using Blog_app_with_EF_Core.model;
using Blog_app_with_EF_Core.repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Blog_app.Test
{
    
    public class PostTest
    {
        private readonly BlogDbContext _context;
        public PostTest()
        {
            _context = DataContext.GetDbContext ();
        }


        [Fact]
        public async void GetAllPosts()
        {
            // arrange 
            var postRepository = new PostRepository(_context);
            // act
            var posts = await postRepository.GetAllPosts();

            // assert
            Assert.NotNull(posts);
        }

        [Fact]
        public async void CreatePost()
        {
            // arrange
            var newPost = new Post(){
                Id = 2,
                Title = "Test Post 2",
                Content = "Test Content 2",
                CreatedAt = DateTime.Now
            };
            
            // act
            var postRepository = new PostRepository(_context);
            var result = await postRepository.CreatePost(newPost);
            // assert
            Assert.NotNull(result);
            Assert.Equal(newPost, result);
        }


        [Fact]
        public async void UpdateValidPost()
        {
            // arrange
            int id = 1;
            var newPost = new Post(){
                Id = 1,
                Title = "Test PostTitle Updated",
                Content = "Test PostContent Updated",
                CreatedAt = DateTime.Now
            };
            
            // act
            var postRepository = new PostRepository(_context);
            var result = await postRepository.UpdatePost(id,newPost);
            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void UpdateNotExistingPost()
        {
            // arrange
            int id = 100;
            var newPost = new Post()
            {
                Id = 1,
                Title = "PostTitle Updated",
                Content = "PostContent Updated",
                CreatedAt = DateTime.Now
            };

            // act
            var postRepository = new PostRepository(_context);
            var result = await postRepository.UpdatePost(id, newPost);
            // assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteValidPost()
        {
            // arrange
            int id = 1;
            // act
            var postRepository = new PostRepository(_context);
            var result = await postRepository.DeletePost(id);
            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void DeleteNotExistingPost()
        {
            // arrange
            int id = 100;
            // act
            var postRepository = new PostRepository(_context);
            var result = await postRepository.DeletePost(id);
            // assert
            Assert.Null(result);
        }
    }
}