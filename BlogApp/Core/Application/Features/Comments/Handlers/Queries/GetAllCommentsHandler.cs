using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.Contracts;
using Application.DTO.CommentDTO;
using Application.Features.Comments.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Handlers.Queries
{
    public class GetAllCommentsHandler : IRequestHandler<GetAllComment, List<CommentResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IComment _commentRepository;
        public GetAllCommentsHandler(IMapper mapper, IComment comment)
        {
            _mapper = mapper;
            _commentRepository = comment;
        }
        public async Task<List<CommentResponseDTO>> Handle(GetAllComment request, CancellationToken cancellationToken)
        {
            var result = await _commentRepository.GetAllComments();
            return _mapper.Map<List<CommentResponseDTO>>(result);
        }
    }
}