using Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services;
        public CategoryController(ICategoryServices categoryServices) {
            _services = categoryServices;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> addCategory(string category_name)
        {
            var res = await _services.addCategory(category_name);
            return StatusCode(res.statuscode, res.message);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> removeCategory(string category_name)
        {
            var res = await _services.removeCategory(category_name);
            return StatusCode(res.statuscode, res.message);
        }
    }
}
