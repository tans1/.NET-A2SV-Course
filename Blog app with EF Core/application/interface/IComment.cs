using Blog_app_with_EF_Core.model;

namespace Blog_app_with_EF_Core.application
{
    public interface IBlogComment
    {
        Task<Comment?> CreateComment(Comment comment);

        Task<List<Comment>?> GetCommentsByPostId(int postId);

        Task<Comment?> GetCommentById(int id);

        Task<Comment?> UpdateComment(int id,Comment comment);

        Task<List<Comment>?> DeleteComment(int id);

        Task<List<Comment>?> GetAllComments();


    }
}
