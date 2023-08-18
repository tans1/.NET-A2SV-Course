using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.CommentDTO;
using MediatR;

namespace Application.Features.Comments.Requests.Queries
{
    public class GetAllComment : IRequest<List<CommentResponseDTO>>
    {}
}