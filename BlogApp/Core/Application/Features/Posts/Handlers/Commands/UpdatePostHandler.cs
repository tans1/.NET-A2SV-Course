using application.Contracts;
using Application.DTO.PostDTO;
using Application.DTO.PostDTO.Validators;
using Application.Exceptions;
using Application.Features.Posts.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Handlers.Commands
{
    public class UpdatePostHandler : IRequestHandler<UpdatePost, PostResponseDTO>
    {
        private readonly IPost _postRepository;
        private readonly IMapper _mapper;
        public UpdatePostHandler(IPost postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostResponseDTO> Handle(UpdatePost request, CancellationToken cancellationToken)
        {
            var validator = new PostUpdateValidator(_postRepository);
            var validationResult = await validator.ValidateAsync(request.updateData);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var post = _mapper.Map<Post>(request.updateData);
            var result = await _postRepository.Update(post);
            return _mapper.Map<PostResponseDTO>(result);
        }
    }
}
