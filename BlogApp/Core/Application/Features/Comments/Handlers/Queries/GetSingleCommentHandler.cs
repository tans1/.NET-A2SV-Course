using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.Contracts;
using Application.DTO.CommentDTO;
using Application.Exceptions;
using Application.Features.Comments.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Handlers.Queries
{
    public class GetSingleCommentHandler : IRequestHandler<GetSingleComment, CommentResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IComment _commentRepository;
        public GetSingleCommentHandler(IMapper mapper, IComment comment)
        {
            _commentRepository = comment;
            _mapper = mapper;
            
        }
        public async Task<CommentResponseDTO> Handle(GetSingleComment request, CancellationToken cancellationToken)
        {

            var comment = await _commentRepository.Get(request.Id);

            if (comment == null)
            {
                throw new NotFoundException("Comment with this Id is not found Please provide valid Id");
            }
            return _mapper.Map<CommentResponseDTO>(comment);

        }
    }
}