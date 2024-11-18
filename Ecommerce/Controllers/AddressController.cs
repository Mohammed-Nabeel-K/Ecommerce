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
    public class AddressController : ControllerBase
    {
        private readonly IAddressServices _addressServices;
        public AddressController(IAddressServices addressServices) 
        {
            _addressServices = addressServices; 
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> allAddressByUser()
        {
            Guid user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var result = await _addressServices.getAllAddress(user_id);
            return Ok(result);
        }

        [Authorize(Roles = "admin,user")]
        [HttpPost("post")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> addAddress(AddressDTO addressdto) 
        {
            var user_id = Guid.Parse(HttpContext.Items["user_id"]?.ToString());
            var result = await _addressServices.addAddress(user_id,addressdto);
            return StatusCode(result.statuscode, result.message);
        }

        [Authorize(Roles = "admin,user")]
        [HttpDelete("remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> removeAddress(Guid address_id)
        {
            var result = await _addressServices.removeAddress(address_id);
            return StatusCode(result.statuscode, result.message);
        }

        [Authorize(Roles = "admin,user")]
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> updateuser(Guid address_id, AddressDTO addressdto) {
            var result = await _addressServices.updateAddress(address_id, addressdto);
            return StatusCode(result.statuscode,result.message);
        }

    }
}
