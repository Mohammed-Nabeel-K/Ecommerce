using Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;
        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("summury/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult summuryAllProd()
        {
            var summary = _adminServices.summaryAllProducts();
            return Ok(summary);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("summuryc/{category_name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult summuryByCategory(string category_name)
        {
            var summary = _adminServices.summaryByCategory(category_name);
            return Ok(summary);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("summuryp/{product_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult summuryByProducts(Guid product_id)
        {
            var summary = _adminServices.summaryByProduct(product_id);
            return Ok(summary);
        }

    }
}
