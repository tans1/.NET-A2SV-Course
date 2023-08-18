using Application.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Contracts
{
    public interface IPost : IGeneric<Post>
    {
        Task<Post?> Get(int id);
        Task<Post?> Update(Post post);
        Task<List<Post>?> GetAllPosts();
    }
}
