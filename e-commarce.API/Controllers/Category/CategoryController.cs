using ecommarce.BLL.DTOs;
using ecommarce.BLL.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommarne.API.Controllers.Category
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryservices _services;
        public CategoryController(ICategoryservices services)
        {
            _services = services;
        }
        [HttpGet]
        [Authorize(Roles ="Admin,User")]

        public async Task<ActionResult<IEnumerable<CategorygetallDto>>> Getall()
        {
            var categories = await _services.Getall();

            if (categories == null || !categories.Any())
            {
                return NotFound();
            }

            return Ok(categories);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<CategoryGetDto>> GetAction(Guid id)
        {
            var category = await _services.GetAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> delete(Guid id) 
        {
            var category= await _services.GetAsync(id);
            if (category == null) {
                return NotFound();
            }
            await _services.deletecategory(id);
            return NoContent();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> add(CategoryAddDto category)
        {
            await _services.addcategory(category);
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task <ActionResult> update(CategoryupdateDto category)
        {
            if (category == null)
                return BadRequest();
            await _services.updatecategory(category);
            return NoContent();
        }
    }
}
