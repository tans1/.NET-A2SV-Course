using Blog_app_with_EF_Core.model;

namespace Blog_app_with_EF_Core.application
{
    public interface IBlogPost
    {
        Task<Post?> CreatePost(Post post);

        Task<List<Post>?> GetAllPosts();

        Task<Post?> GetPostbyId(int id);

        Task<Post?> UpdatePost(int id, Post data);

        Task<List<Post>?> DeletePost(int id);
    }
}
