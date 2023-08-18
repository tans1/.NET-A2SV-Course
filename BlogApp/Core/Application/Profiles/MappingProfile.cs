using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.CommentDTO;
using Application.DTO.PostDTO;
using AutoMapper;
using Domain.Entities;

namespace application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<PostResponseDTO, Post>().ReverseMap();
            CreateMap<PostCreateDTO, Post>().ReverseMap();
            CreateMap<PostUpdateDTO, Post>().ReverseMap();

            CreateMap<CommentCreateDTO, Comment>().ReverseMap();
            CreateMap<CommentUpdateDTO, Comment>().ReverseMap();
            CreateMap<CommentResponseDTO, Comment>().ReverseMap();
        }
    }
}
