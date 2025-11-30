using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalDiscountsController : ControllerBase
    {
        private readonly IGlobalDiscounts _repository;

        public GlobalDiscountsController(IGlobalDiscounts repository)
        {
            _repository = repository;
        }

        [HttpGet("Lista")]
        public async Task<ActionResult> GetGlobalDiscounts()
        {
            return Ok(await _repository.GetGlobalDiscounts());
        }

        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult> GetGlobalDiscount(Guid id)
        {
            var result = await _repository.GetGlobalDiscount_Id(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("Crear")]
        public async Task<ActionResult> CreateGlobalDiscount(GlobalDiscounts discount)
        {
            var result = await _repository.CreateGlobalDiscount(discount);
            return Ok(result);
        }

        [HttpPut("Actualizar")]
        public async Task<ActionResult> UpdateGlobalDiscount(GlobalDiscounts discount)
        {
            var result = await _repository.UpdateGlobalDiscount(discount);
            return Ok(result);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult> DeleteGlobalDiscount(Guid id)
        {
            var deleted = await _repository.DeleteGlobalDiscount(id);

            if (!deleted)
                return NotFound();

            return Ok("Eliminado");
        }
    }
}
