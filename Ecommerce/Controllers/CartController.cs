using Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public readonly ICartServices _cartServices;

        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }


        [Authorize(Roles = "user")]
        [HttpPost("addToCart/{product_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> addProducttoCart(Guid product_id,int quantity)
        {
            var userid = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var result = await _cartServices.addProducttoCart(product_id,userid, quantity);
            return StatusCode(result.statuscode,result.message);
        }

        [Authorize(Roles = "user")]
        [HttpDelete("remove/{cartItem_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> removeFromCart(Guid cartItem_id)
        {
            var userid = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var result = await _cartServices.removeFromCart(cartItem_id,userid);
            return StatusCode(result.statuscode, result.message);
        }

        [Authorize(Roles = "user")]
        [HttpPost("checkout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> checkout(Guid address_id)
        {
            var user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var result = await _cartServices.checkoutFromCart(user_id,address_id);
            return StatusCode(result.statuscode, result.message);
        }

        [Authorize(Roles = "user")]
        [HttpGet("cartitems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> allcartItems()
        {
            var user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var userId = HttpContext.User.Claims.FirstOrDefault(n => n.Type == ClaimTypes.NameIdentifier);
            var result = await _cartServices.getAllFromCart(user_id);
            if(result == null)
            {
                return StatusCode(500, "Internal server error");
            }
            return Ok(result);

        }
    }
}
