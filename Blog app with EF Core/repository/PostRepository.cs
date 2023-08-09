using Blog_app_with_EF_Core.application;
using Blog_app_with_EF_Core.data;
using Blog_app_with_EF_Core.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog_app_with_EF_Core.repository
{
    public class PostRepository : IBlogPost
    {
        public readonly BlogDbContext _context;
        public PostRepository(BlogDbContext database)
        {
            _context = database;
        }


        public async Task<Post> CreatePost(Post post)
        {
            
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }


        public async Task<List<Post>> GetAllPosts()
        {
            var posts = await _context.Posts
                                .Include(p => p.Comments)
                                .ToListAsync();
            return posts;
        }

        public async Task<Post> GetPostbyId(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post;
        }


        public async Task<Post> UpdatePost(int id, Post data)
        {
            var post = _context.Posts.Find(id);

            if (post != null)
            {
                post.Title = data.Title;
                post.Content = data.Content;

                _context.Posts.Update(post);
                await _context.SaveChangesAsync();
            }
            
            return post;

        }

        public async Task<List<Post>> DeletePost(int id)
        {
            var post = _context.Posts.Find(id);

            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
                return await GetAllPosts();
            }
            return null;
        }
    }

}
