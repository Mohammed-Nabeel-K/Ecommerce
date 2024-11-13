using Ecommerce.DTOs;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminActionController : ControllerBase
    {
        public readonly IConfiguration _config;
        public readonly IAdminActionServices _adminActions;

        public AdminActionController(IConfiguration configuration,IAdminActionServices adminAction)
        {
            _adminActions = adminAction;
            _config = configuration;
        }

        [HttpGet("allUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<UserDTO>> getAllUsers()
        {
            var res = _adminActions.getAllUsers();
            return Ok(res);
        }

        [HttpGet("UserByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ICollection<UserDTO>> getUsersByName(string name) 
        { 
            var users = _adminActions.getUsersWithName(name);
            return Ok(users);
        }

        [HttpGet("Product/{category}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ICollection<Product>> productWithCategory(string category)
        {
            var products = _adminActions.getProductsBYCategory(category);
            return Ok(products);
        }

        [HttpGet("product/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> productWithId(int id) {
            var result = _adminActions.getProductById(id);
            if (result == null) {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("addProduct")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        public IActionResult AddProduct(Product product)
        {
            _adminActions.AddProduct(product);
            return Ok();
        }

        [HttpDelete("delete/product/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult removeProduct(int id) {
            _adminActions.DeleteProduct(id);
            return Ok();
        }

        [HttpPut("update/Product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult updateProduct(Product product) {
            _adminActions.UpdateProduct(product);
            return Ok();    
        }

    }
}
