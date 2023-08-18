using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.CommentDTO;
using MediatR;

namespace Application.Features.Comments.Requests.Commands
{
    public class UpdateComment : IRequest<CommentResponseDTO>
    {
        public CommentUpdateDTO updateData { get; set; }
    }
}