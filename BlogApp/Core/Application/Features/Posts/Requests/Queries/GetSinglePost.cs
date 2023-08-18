using Application.DTO.PostDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Requests.Queries
{
    public class GetSinglePost : IRequest<PostResponseDTO>
    {
        public int Id { get; set; }
    }
}
