using application.Contracts;
using Application.DTO.PostDTO;
using Application.DTO.PostDTO.Validators;
using Application.Exceptions;
using Application.Features.Posts.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Postss.Handlers.Commands
{
    public class CreatePostHandler : IRequestHandler<CreatePost, PostResponseDTO>
    {
        private readonly IPost _postRepository;
        private readonly IMapper _mapper;

        public CreatePostHandler(IPost postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<PostResponseDTO> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var validator = new PostCreateValidator();
            var validationResult = await validator.ValidateAsync(request.postData);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var newPost = _mapper.Map<Post>(request.postData);
            var result = await _postRepository.Create(newPost);
            return _mapper.Map<PostResponseDTO>(result);
        }
    }
}
