using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.Contracts;
using Application.DTO.CommentDTO;
using Application.Exceptions;
using Application.Features.Comments.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Handlers.Commands
{
    public class DeleteCommentHandler : IRequestHandler<DeleteComment, CommentResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IComment _commentRepository;
        public DeleteCommentHandler(IMapper mapper, IComment comment)
        {
            _mapper = mapper;
            _commentRepository = comment;
        }

        public async Task<CommentResponseDTO> Handle(DeleteComment request, CancellationToken cancellationToken)
        {
            var result = await _commentRepository.Delete(request.Id);

            if (result == null)
            {
                throw new NotFoundException($"Comment with Id : {request.Id} is not found, Please provide valid Id");
            }

            return _mapper.Map<CommentResponseDTO>(result);
        }
    }
}