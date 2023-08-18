
using application.Contracts;
using Application.Contracts.Infrastructure;
using Application.DTO.PostDTO;
using Application.Features.Posts.Requests.Queries;
using Application.Model;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Handlers.Queries
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPosts, List<PostResponseDTO>>
    {
        private readonly IPost _postRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public GetAllPostsHandler(IPost postRepository, IMapper mapper, IEmailService emailService) 
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _emailService = emailService;
        }
        public async Task<List<PostResponseDTO>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
            var allPosts = await _postRepository.GetAllPosts();


            // send the email
            var email = new Email()
            {
                To = "tofikabdu2002@gmail.com",
                Subject = "Blog API Email Practice",
                Body = "Blog API Post Is Created"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _mapper.Map<List<PostResponseDTO>>(allPosts);
        }
    }
}
