using AutoMapper;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        public readonly IUserAuthServices _userAuthServices;
        public readonly IConfiguration _configuration;
        
        public UserAuthController(IConfiguration config, IUserAuthServices userService)
        {
            _configuration = config;
            _userAuthServices = userService;    
            
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] UserDTO model)
        {
            _userAuthServices.Register(model);
            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            try
            {
                var loginData = _userAuthServices.Login(model);
                if (loginData == null)
                {
                    return NotFound("not found");
                }
                var token = CreateToken(loginData);
                return Ok(token);
            }
            catch (Exception ex) {
                return StatusCode(500, "Internal server error");
            }
           
        }

        private string CreateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var  credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim (ClaimTypes.NameIdentifier,user.user_id.ToString()),
                new Claim (ClaimTypes.Name,user.Name),
                new Claim (ClaimTypes.Role,user.Roles)
            };

            var token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: credentials,
                    expires: DateTime.Now.AddDays(1)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
