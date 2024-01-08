using GTwitt.BUSINESS.DTOs.AuthDTOs;
using GTwitt.BUSINESS.ExternalServices.Implements;
using GTwitt.BUSINESS.ExternalServices.Interfaces;
using GTwitt.BUSINESS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTwitt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IUserServices _userServices { get; }
        IEmailServices _emailServices { get; }

        public AuthsController(IUserServices userServices, IEmailServices emailServices)
        {
            _userServices = userServices;
            _emailServices = emailServices;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            await _userServices.RegisterAsync(dto);
			_emailServices.Send(dto.Email, "Twitt", "Welcome to Twitt");
			return Ok();
        }

    }
}
