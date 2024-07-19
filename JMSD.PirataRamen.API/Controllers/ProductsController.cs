using JMSD.PirataRamen.API.Interfaces;
using JMSD.PirataRamen.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace JMSD.PirataRamen.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetProductsAsync()
        {
            try
            {
                var products = await _productService.GetProductsAsync();
                return Ok(products);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] Product product)
        {
            try
            {
                var result = await _productService.CreateProductAsync(product);
                if (result > 0)
                {
                    return Ok();
                } 
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromBody] Product product)
        {
            try
            {
                var result = await _productService.UpdateProductAsync(product);
                if (result > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
        {
            try
            {
                var result = await _productService.DeleteProductAsync(id);
                if (result > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
