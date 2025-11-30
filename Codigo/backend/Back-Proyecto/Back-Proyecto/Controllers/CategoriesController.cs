using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategories _categoriesRepository;

        public CategoriesController(ICategories categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet("Obtener")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoriesRepository.GetCategories();
            return Ok(categories);
        }

        [HttpGet("Obtener/{id}")]
        public async Task<IActionResult> GetCategory_Id(Guid id)
        {
            var category = await _categoriesRepository.GetCategory_Id(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CreateCategory([FromBody] Categories category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdCategory = await _categoriesRepository.CreateCategory(category);
            return CreatedAtAction(nameof(GetCategory_Id), new { id = createdCategory.Category_Id }, createdCategory);
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> UpdateCategory([FromBody] Categories category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedCategory = await _categoriesRepository.UpdateCategory(category);
            if (updatedCategory == null) return NotFound();

            return Ok(updatedCategory);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var deleted = await _categoriesRepository.DeleteCategory(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
