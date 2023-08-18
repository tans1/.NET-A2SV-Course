using Application.Contracts;
using Domain.Entities;


namespace application.Contracts
{
    public interface IComment : IGeneric<Comment>
    {
        Task<Comment?> Get(int id);
        Task<Comment?> Update(Comment comment);
        Task<List<Comment>?> GetAllComments();
        Task<List<Comment>?> GetCommentsByPostId(int postId);
    }
}
