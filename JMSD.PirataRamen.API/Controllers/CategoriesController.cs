using JMSD.PirataRamen.API.Interfaces;
using JMSD.PirataRamen.API.Models;
using JMSD.PirataRamen.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace JMSD.PirataRamen.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] int id)
        {
            try
            {
                var category = await _categoryService.GetByCategoryIdAsync(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] Category category)
        {
            try
            {
                var result = await _categoryService.CreateCategoryAsync(category);
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
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] Category category)
        {
            try
            {
                var result = await _categoryService.UpdateCategoryAsync(category);
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
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] int id)
        {
            try
            {
                var result = await _categoryService.DeleteCategoryAsync(id);
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
