using AutoMapper;
using GTwitt.BUSINESS.DTOs.PostDTOs;
using GTwitt.BUSINESS.DTOs.TopicDTOs;
using GTwitt.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.Profiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<PostCreateDTO, Post>();
            CreateMap<PostUpdateDTO, Post>();
            CreateMap<Post, PostListItemDTO>();
            CreateMap<Post, PostDetailDTO>();
        }
    }
}
