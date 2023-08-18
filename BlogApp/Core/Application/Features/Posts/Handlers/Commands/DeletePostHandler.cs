using application.Contracts;
using Application.DTO.PostDTO;
using Application.Exceptions;
using Application.Features.Posts.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Handlers.Commands
{
    public class DeletePostHandler : IRequestHandler<DeletePost, PostResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPost _postRepository;

        public DeletePostHandler(IMapper mapper, IPost postRepository)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostResponseDTO> Handle(DeletePost request, CancellationToken cancellationToken)
        {
            var response = await _postRepository.Delete(request.Id);
            if (response == null)
            {
                throw new NotFoundException("Post with this Id is not found to delete, Please provide a valid Id");
            }
            return _mapper.Map<PostResponseDTO>(response);
        }
    }
}
