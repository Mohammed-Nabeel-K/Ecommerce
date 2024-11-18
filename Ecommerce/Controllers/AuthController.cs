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
    public class AuthController : ControllerBase
    {
        public readonly IAuthServices _userAuthServices;
        public readonly IConfiguration _configuration;

        public AuthController(IConfiguration config, IAuthServices userService)
        {
            _configuration = config;
            _userAuthServices = userService;

        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody] UserDTO model)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            
            var result = await _userAuthServices.Register(model);

            return StatusCode(result.statuscode,result.message);
            
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var log = await _userAuthServices.Login(model);
            return StatusCode(log.statuscode, log.message);

        }

       
    }
}
