using Ecommerce.DTOs;
using Ecommerce.Services;
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

        [HttpGet("allUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<UserDTO>> getAllUsers()
        {
            var res = _userServices.getAllUsers();
            return Ok(res);
        }

        [HttpGet("UserByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ICollection<UserDTO>> getUsersByName(string name)
        {
            var users = _userServices.getUsersWithName(name);
            return Ok(users);
        }


    }
}
