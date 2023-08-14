using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application.DTO;
using AutoMapper;
using Domain.Entities;

namespace application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<PostDTO, Post>().ReverseMap();
            CreateMap<CommentDTO, Comment>().ReverseMap();

        }
    }
}
