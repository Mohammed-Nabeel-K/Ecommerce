using Ecommerce.DTOs;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet("allproducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<ProductGetDTO>>> getproducts() {
            var res = await _productServices.GetProducts();
            return Ok(res);
        }

        [HttpGet("{category}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<Product>>> productWithCategory(string category)
        {
            var products = await _productServices.getProductsBYCategory(category);
            return Ok(products);
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDTO>> productWithId(Guid id)
        {
            var result = await _productServices.getProductById(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("addProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddProduct(ProductDTO productdto)
        {
            var res = await _productServices.AddProduct(productdto);
            
            return StatusCode(res.statuscode,res.message);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> removeProduct(Guid id)
        {
            var res = await _productServices.DeleteProduct(id);
            
            return StatusCode(res.statuscode, res.message);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> updateProduct(ProductGetDTO productdto)
        {
            var res = await _productServices.UpdateProduct(productdto);
            
            return StatusCode(res.statuscode,res.message);
        }
    }
}
