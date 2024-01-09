using GTwitt.BUSINESS.DTOs.AuthDTOs;
using GTwitt.BUSINESS.ExternalServices.Implements;
using GTwitt.BUSINESS.ExternalServices.Interfaces;
using GTwitt.BUSINESS.Services.Interfaces;
using GTwitt.CORE.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GTwitt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signinManager;
		IUserServices _userServices { get; }
        IEmailServices _emailServices { get; }

        public AuthsController(IUserServices userServices, UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, IEmailServices emailServices)
        {
            _signinManager = signinManager;
            _userManager = userManager;
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

		//[HttpPost("Login")]
		//public async Task<IActionResult> Login(LoginDTO dto)
		//{
  //          AppUser user;
		//	user = await _userManager.FindByNameAsync(dto.Username);
  //          await _signinManager.CheckPasswordSignInAsync(user, dto.Password, true);
		//	return Ok("Logged");
		//}

		[HttpPost, Route("login")]
		public IActionResult Login(LoginDTO dto)
		{
			if (dto == null)
			{
				return BadRequest("Invalid client request");
			}
			if (dto.Username == "johndoe" && dto.Password == "johndoe2410")
			{
				var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
				var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
				var tokenOptions = new JwtSecurityToken(
					issuer: "CodeMaze",
					audience: "https://localhost:5001",
					claims: new List<Claim>(),
					expires: DateTime.Now.AddMinutes(5),
					signingCredentials: signinCredentials
				);
				var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
				return Ok(new { Token = tokenString });
			}
			else
			{
				return Unauthorized();
			}
		}


	}
}
