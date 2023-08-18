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
    public class CommentRepository : GenericRepository<Comment> , IComment
    {
        private readonly BlogDataContext _context;

        public CommentRepository(BlogDataContext context): base(context)
        {
            _context = context;
        }

        public async Task<Comment?> Get(int Id)
        {
            return await _context.Comments.FindAsync(Id);
        }


        public async Task<List<Comment>?> GetAllComments()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<List<Comment>?> GetCommentsByPostId(int postId)
        {
            var comments = await _context.Comments
                                    .Where(comment => comment.PostId == postId)
                                    .ToListAsync();
            return comments;
        }

        public async Task<Comment?> Update(Comment commentData)
        {
            var comment = await _context.Comments.FindAsync(commentData.Id);
            if (comment != null)
            {
                comment.Text = commentData.Text;
                comment.PostId = comment.PostId;

                _context.Comments.Update(comment);
                await _context.SaveChangesAsync();
            }
            return comment;
        }

    }

}
