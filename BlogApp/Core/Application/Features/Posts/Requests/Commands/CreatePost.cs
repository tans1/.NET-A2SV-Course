using Application.DTO.PostDTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Requests.Commands
{
    public class CreatePost : IRequest<PostResponseDTO>
    {
        public PostCreateDTO postData { get; set; }
    }
}
