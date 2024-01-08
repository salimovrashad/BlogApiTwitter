using AutoMapper;
using GTwitt.BUSINESS.DTOs.AuthDTOs;
using GTwitt.BUSINESS.Exceptions.User;
using GTwitt.BUSINESS.Services.Interfaces;
using GTwitt.CORE.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.Services.Implements
{
    public class UserServices : IUserServices
    {
        UserManager<AppUser> _userManager { get; }
        IMapper _mapper { get; }

        public UserServices(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task RegisterAsync(RegisterDTO dto)
        {
            var user = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in result.Errors)
                {
                    sb.Append(item.Description + " ");
                }
                throw new RegisterFailedException(sb.ToString().TrimEnd());
            }
        }
    }
}
