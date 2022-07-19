using System;
using Microsoft.AspNetCore.Mvc;
using Cookbook.DAL;
using Microsoft.AspNetCore.Authorization;
using Cookbook.DTOs;
using Cookbook.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Cookbook.Settings;
using Microsoft.Extensions.Options;
using Cookbook.DTOs.Converters;

namespace Cookbook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly AppSettings _appSettings;

        public UserController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody]UserRegisterDTO userDto)
        {
            try
            {
                _unitOfWork.UserRepository.Register(userDto);
                _unitOfWork.Save();
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UserAuthenticateDTO userDto)
        {
            var user = _unitOfWork.UserRepository.Authenticate(userDto.Login, userDto.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Login or password is incorrect" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new UserAuthenticatedDTO 
            { 
                UserID = user.UserID,
                Login = userDto.Login,
                Password = userDto.Password,
                Name = user.Name,
                Token = tokenString
            });
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUserByID(int id)
        {
            var user = _unitOfWork.UserRepository.GetByID(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToDTO());
        }
    }
}
