using GTwitt.BUSINESS.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.Services.Interfaces
{
    public interface IUserServices
    {
        public Task RegisterAsync(RegisterDTO dto);
    }
}
