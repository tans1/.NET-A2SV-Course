using application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Contracts
{
    public interface IComment
    {
        Task<Comment?> CreateComment(CommentDTO comment);

        Task<List<Comment>?> GetCommentsByPostId(int postId);

        Task<Comment?> GetCommentById(int id);

        Task<Comment?> UpdateComment(int id, CommentDTO comment);

        Task<List<Comment>?> DeleteComment(int id);

        Task<List<Comment>?> GetAllComments();
    }
}
