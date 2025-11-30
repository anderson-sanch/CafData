using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountedProductsController : ControllerBase
    {
        private readonly IDiscountedProducts _repository;

        public DiscountedProductsController(IDiscountedProducts repository)
        {
            _repository = repository;
        }

        [HttpGet("Lista")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Create([FromBody] DiscountedProducts item)
        {
            var created = await _repository.Add(item);
            return Ok(created);
        }

        [HttpDelete("Eliminar/{productId}/{globalId}")]
        public async Task<IActionResult> Delete(Guid productId, Guid globalId)
        {
            var deleted = await _repository.Delete(productId, globalId);
            if (!deleted) return NotFound();
            return Ok(new { message = "Registro eliminado" });
        }
    }
}
