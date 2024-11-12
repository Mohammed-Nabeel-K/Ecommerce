using AutoMapper;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Login([FromBody] LoginDTO model)
        {
            var loginData = _userAuthServices.Login(model);
            if ( loginData == null)
            {
                return NotFound("not found");
            }
            return Ok("login successful");
        }


    }
}
