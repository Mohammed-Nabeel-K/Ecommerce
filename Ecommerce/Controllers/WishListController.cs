using Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListServices _wishlistservice;

        public WishListController(IWishListServices wishListServices)
        {
            _wishlistservice = wishListServices;
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult addToWishlist(Guid product_id) {
            var user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var res = _wishlistservice.addWishList(product_id,user_id);
            return StatusCode(res.statuscode,res.message);
        }

        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult removeFromWishlist(Guid product_id)
        {
            var user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var res = _wishlistservice.deleteWishList(product_id,user_id);
            return StatusCode(res.statuscode, res.message);
        }
    }
}
