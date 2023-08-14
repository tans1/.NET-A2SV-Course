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
    public class CommentRepository : IComment
    {
        private readonly BlogDataContext _context;
        private readonly IMapper _mapper;

        public CommentRepository(BlogDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Comment?> CreateComment(CommentDTO comment)
        {
            try
            {
                var newComment = _mapper.Map<Comment>(comment);
                _context.Comments.Add(newComment);
                await _context.SaveChangesAsync();
                return newComment;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Comment>?> GetAllComments()
        {
            return await _context.Comments.ToListAsync();
        }


        public async Task<Comment?> GetCommentById(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<List<Comment>?> GetCommentsByPostId(int postId)
        {
            var comments = await _context.Comments
                                    .Where(comment => comment.PostId == postId)
                                    .ToListAsync();
            return comments;
        }

        public async Task<Comment?> UpdateComment(int id, CommentDTO commentData)
        {
            var comment = await _context.Comments.FindAsync(id);
            var newComment = _mapper.Map<Comment>(commentData);

            if (comment != null)
            {
                comment.Text = newComment.Text;
                comment.PostId = comment.PostId;

                _context.Comments.Update(comment);
                await _context.SaveChangesAsync();
            }
            return comment;
        }

        public async Task<List<Comment>?> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
                return await GetAllComments();
            }
            return null;
        }
    }

}
