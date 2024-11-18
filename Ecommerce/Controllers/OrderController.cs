using Ecommerce.Data;
using Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices) {

            _orderServices = orderServices;
        }

        [Authorize(Roles = "user")]
        [HttpPost("add/order")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> orderAProduct(Guid product_id, int quantity,Guid address_id)
        {
            var user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            if(user_id == null)
            {
                return Unauthorized();
            }
            var result = await _orderServices.placeOrder(product_id,user_id,quantity,address_id);
            return StatusCode(result.statuscode, result.message);
        }

        [Authorize(Roles = "admin,user")]
        [HttpPut("update/{order_id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> orderUpdate(Guid order_id, string order_status) 
        {
            var result = await _orderServices.updateOrder(order_id, order_status);
            return StatusCode(result.statuscode,result.message);
        }

        [Authorize(Roles = "admin,user")]
        [HttpDelete("delete/{order_id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> cancelDelete(Guid order_id) 
        { 
            var result = await _orderServices.deleteOrder(order_id);
            return StatusCode(result.statuscode, result.message);
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet("orderbyUser")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> orderslistForUser()
        {
            var user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var result = await _orderServices.getOrdersByUser(user_id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [Authorize(Roles = "admin")]
        [HttpGet("allorders")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> orderslist()
        {
            
            var result = await _orderServices.getOrders();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
