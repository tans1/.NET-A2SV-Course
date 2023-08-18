using application.Contracts;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.DataContext;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class PostRepository : GenericRepository<Post> , IPost
    {
        private readonly BlogDataContext _context;

        public PostRepository(BlogDataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Post>?> GetAllPosts()
        {
            var posts = await _context.Posts
                                .Include(p => p.Comments)
                                .ToListAsync();
            return posts;
        }

        public async Task<Post?> Get(int id)
        {
            var post = await _context.Posts
                        .Include(p => p.Comments)
                        .FirstOrDefaultAsync(p => p.Id == id);
            return post;
        }


        public async Task<Post?> Update(Post data)
        {
            var post = await _context.Posts
                        .Include(p => p.Comments)
                        .FirstOrDefaultAsync(p => p.Id == data.Id);


            if (post != null)
            {
                post.Title = data.Title;
                post.Content = data.Content;

                _context.Posts.Update(post);
                await _context.SaveChangesAsync();
            }
            return post;
        }
    }
}
