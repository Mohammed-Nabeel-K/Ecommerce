﻿using Ecommerce.DTOs;
using Ecommerce.Models;
using Ecommerce.Services;
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

        [HttpGet("{category}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ICollection<Product>> productWithCategory(string category)
        {
            var products = _productServices.getProductsBYCategory(category);
            return Ok(products);
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductDTO> productWithId(Guid id)
        {
            var result = _productServices.getProductById(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("addProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddProduct(ProductDTO productdto)
        {
            var res = _productServices.AddProduct(productdto);
            
            return StatusCode(res.statuscode,res.message);
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult removeProduct(Guid id)
        {
            var res = _productServices.DeleteProduct(id);
            
            return StatusCode(res.statuscode, res.message);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult updateProduct(ProductGetDTO productdto)
        {
            var res = _productServices.UpdateProduct(productdto);
            
            return StatusCode(res.statuscode,res.message);
        }
    }
}