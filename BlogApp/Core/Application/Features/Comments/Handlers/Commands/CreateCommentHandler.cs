using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.Contracts;
using Application.DTO.CommentDTO;
using Application.DTO.CommentDTO.Validators;
using Application.Exceptions;
using Application.Features.Comments.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Handlers.Commands
{
    public class CreateCommentHandler : IRequestHandler<CreateComment, CommentResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IComment _commentRepository;
        public CreateCommentHandler(IMapper mapper, IComment comment)
        {
            _mapper = mapper;
            _commentRepository = comment;
        }

        public async Task<CommentResponseDTO> Handle(CreateComment request, CancellationToken cancellationToken)
        {
            var validator = new CommentCreateValidator();
            var validationResult = await validator.ValidateAsync(request.commentData);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var comment = _mapper.Map<Comment>(request.commentData);
            var result = await _commentRepository.Create(comment);

            return _mapper.Map<CommentResponseDTO>(result);
        }
    }
}