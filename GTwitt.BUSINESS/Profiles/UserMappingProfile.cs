using AutoMapper;
using GTwitt.BUSINESS.DTOs.AuthDTOs;
using GTwitt.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterDTO, AppUser>();
        }
    }
}
