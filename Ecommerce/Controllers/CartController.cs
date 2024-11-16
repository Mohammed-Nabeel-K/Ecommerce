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

        public IActionResult addProducttoCart(Guid product_id,int quantity)
        {
            var userid = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var result = _cartServices.addProducttoCart(product_id,userid, quantity);
            return StatusCode(result.statuscode,result.message);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public  IActionResult removeFromCart(Guid cartItem_id)
        {
            var result = _cartServices.removeFromCart(cartItem_id);
            return StatusCode(result.statuscode, result.message);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult checkout()
        {
            var user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var result = _cartServices.checkoutFromCart(user_id);

            return StatusCode(result.statuscode, result.message);
        }
    }
}
