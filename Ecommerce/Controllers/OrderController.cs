using Ecommerce.Data;
using Ecommerce.Services;
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

        [HttpPost("add/order")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult orderAProduct(Guid product_id, int quantity)
        {
            var user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            if(user_id == null)
            {
                return Unauthorized();
            }
            var result = _orderServices.placeOrder(product_id,user_id,quantity);
            return StatusCode(result.statuscode, result.message);
        }

        [HttpPut("update/{order_id}")]
        public IActionResult orderUpdate(Guid order_id, string order_status) 
        {
            var result = _orderServices.updateOrder(order_id, order_status);
            return StatusCode(result.statuscode,result.message);
        }

        [HttpDelete("delete/{order_id}")]
        public IActionResult orderDelete(Guid order_id) 
        { 
            var result = _orderServices.deleteOrder(order_id);
            return StatusCode(result.statuscode, result.message);
        }

        [HttpGet("orderbyUser")]
        public IActionResult orderslistForUser()
        {
            var user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var result = _orderServices.getOrdersByUser(user_id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [HttpGet("allorders")]
        public IActionResult orderslist()
        {
            
            var result = _orderServices.getOrders();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
