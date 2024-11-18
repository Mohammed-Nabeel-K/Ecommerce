using Azure;
using Ecommerce.DTOs;
using Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("allUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<UserDTO>>> getAllUsers()
        {
            var res = await _userServices.getAllUsers();
            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("UserByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<UserDTO>>> getUsersByName(string name)
        {
            var users = await _userServices.getUsersWithName(name);
            return Ok(users);
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{username}/block")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound )]
        public async Task<IActionResult> blockUser(string username )
        {
            if (username == null) { return BadRequest(); }
            var res = await _userServices.blockUser(username);
            return StatusCode(res.statuscode, res.message);
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{username}/unblock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> unblockUser(string username)
        {
            if (username == null) { return BadRequest(); }
            var res = await _userServices.unblockUser(username);
            return StatusCode(res.statuscode, res.message);
        }
    }
}
