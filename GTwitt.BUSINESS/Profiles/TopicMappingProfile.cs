using AutoMapper;
using GTwitt.BUSINESS.DTOs.TopicDTOs;
using GTwitt.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.Profiles
{
    public class TopicMappingProfile : Profile
    {
        public TopicMappingProfile()
        {
            CreateMap<TopicCreateDTO, Topic>();
            CreateMap<TopicUpdateDTO, Topic>();
            CreateMap<Topic, TopicListItemDTO>();
            CreateMap<Topic, TopicDetailDTO>();
        }
    }
}
