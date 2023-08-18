using application.Contracts;
using Application.DTO.PostDTO;
using Application.Exceptions;
using Application.Features.Posts.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Handlers.Queries
{
    public class GetSinglePostHandler : IRequestHandler<GetSinglePost, PostResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPost _postRepository;
        public GetSinglePostHandler(IMapper mapper, IPost postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<PostResponseDTO> Handle(GetSinglePost request, CancellationToken cancellationToken)
        {
            var singlePost = await _postRepository.Get(request.Id);

            if (singlePost == null)
            {
                throw new NotFoundException("Post with this Id is not found,please provide valid Id");
            }

            return _mapper.Map<PostResponseDTO>(singlePost);
        }
    }
}
