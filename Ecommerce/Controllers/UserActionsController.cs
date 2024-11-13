using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActionsController : ControllerBase
    {
        public readonly IUserActionServices _userAction;
        public UserActionsController(IUserActionServices userActionServices)
        {
            _userAction = userActionServices;
        }

        [Authorize]
        [HttpPost("addproducttocart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        
        public IActionResult addProducttoCart(int product_id)
        {
            var userid =int.Parse( User.FindFirstValue(ClaimTypes.NameIdentifier));
            _userAction.addProducttoCart(product_id, userid);
            return Ok();
        }
        [HttpPost("addcart")]

        public IActionResult addcart() {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _userAction.addCart(userid);
            return Ok();
        }
    }
}
