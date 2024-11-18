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

        [Authorize(Roles = "user")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> addToWishlist(Guid product_id) {
            var user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var res = await _wishlistservice.addWishList(product_id,user_id);
            return StatusCode(res.statuscode,res.message);
        }

        [Authorize(Roles = "user")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> removeFromWishlist(Guid product_id)
        {
            var user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var res = await _wishlistservice.deleteWishList(product_id,user_id);
            return StatusCode(res.statuscode, res.message);
        }
    }
}
