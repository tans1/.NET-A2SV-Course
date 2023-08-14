using application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Contracts
{
    public interface IPost
    {
        Task<Post?> CreatePost(PostDTO post);

        Task<List<Post>?> GetAllPosts();

        Task<Post?> GetPostbyId(int id);

        Task<Post?> UpdatePost(int id, PostDTO data);

        Task<List<Post>?> DeletePost(int id);
    }
}
