using application.Contracts;
using application.DTO;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class PostRepository : IPost
    {
        private readonly BlogDataContext _context;
        private readonly IMapper _mapper;

        public PostRepository(BlogDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Post?> CreatePost(PostDTO post)
        {
            try
            {
                var newPost = _mapper.Map<Post>(post);
                _context.Posts.Add(newPost);
                await _context.SaveChangesAsync();
                return newPost;
            }
            catch
            {
                return null;
            }

        }


        public async Task<List<Post>?> GetAllPosts()
        {
            var posts = await _context.Posts
                                .Include(p => p.Comments)
                                .ToListAsync();
            return posts;
        }

        public async Task<Post?> GetPostbyId(int id)
        {
            var post = await _context.Posts
                        .Include(p => p.Comments)
                        .FirstOrDefaultAsync(p => p.Id == id);
            return post;
        }


        public async Task<Post?> UpdatePost(int id, PostDTO data)
        {
            var post = await _context.Posts
                        .Include(p => p.Comments)
                        .FirstOrDefaultAsync(p => p.Id == id);

            var newPostData = _mapper.Map<Post>(data);

            if (post != null)
            {
                post.Title = newPostData.Title;
                post.Content = newPostData.Content;

                _context.Posts.Update(post);
                await _context.SaveChangesAsync();
            }
            return post;
        }

        public async Task<List<Post>?> DeletePost(int id)
        {
            var post = await _context.Posts
                        .Include(p => p.Comments)
                        .FirstOrDefaultAsync(p => p.Id == id);
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
}
