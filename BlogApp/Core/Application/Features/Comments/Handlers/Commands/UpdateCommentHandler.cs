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
    public class UpdateCommentHandler : IRequestHandler<UpdateComment, CommentResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IComment _commentRepository;
        public UpdateCommentHandler(IMapper mapper, IComment comment)
        {
            _mapper = mapper;
            _commentRepository = comment;
        }
        public async Task<CommentResponseDTO> Handle(UpdateComment request, CancellationToken cancellationToken)
        {
            var validator = new CommentUpdateValidator(_commentRepository);
            var validationResult = await validator.ValidateAsync(request.updateData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var updatedComment = _mapper.Map<Comment>(request.updateData);
            var result = await _commentRepository.Update(updatedComment);
                
            return _mapper.Map<CommentResponseDTO>(result);
        }
    }
}