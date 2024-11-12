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

        [HttpGet("ProductByCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ICollection<Product>> productWithCategory(string category)
        {
            var products = _adminActions.getProductsBYCategory(category);
            return Ok(products);
        }
        
    }
}
