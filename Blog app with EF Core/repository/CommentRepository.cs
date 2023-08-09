using Blog_app_with_EF_Core.application;
using Blog_app_with_EF_Core.data;
using Blog_app_with_EF_Core.model;
using Microsoft.EntityFrameworkCore;

namespace Blog_app_with_EF_Core.repository
{
    public class CommentRepository : IBlogComment
    {
        private readonly BlogDbContext _context;

        public CommentRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _context.Comments.ToListAsync();
        }
        

        public async Task<Comment> GetCommentById(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<List<Comment>> GetCommentsByPostId(int postId)
        {
            var comments = await _context.Comments
                                    .Where(comment => comment.PostId == postId)
                                    .ToListAsync();

            return comments;
        }

        public async Task<Comment> UpdateComment(int id,Comment newComment)
        {
            var comment = _context.Comments.Find(id);

            if (comment != null)
            {
                comment.Text = newComment.Text;
                comment.PostId = newComment.PostId;

                _context.Comments.Update(comment);
                await _context.SaveChangesAsync();
            }
            return comment;
        }

        public async Task<List<Comment>> DeleteComment(int id)
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
