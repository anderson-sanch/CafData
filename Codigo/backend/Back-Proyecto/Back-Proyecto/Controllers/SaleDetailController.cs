using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailController : ControllerBase
    {
        private readonly ISale_Detail _repo;

        public SaleDetailController(ISale_Detail repo)
        {
            _repo = repo;
        }

        // ============================================================
        // GET: api/SaleDetail/Obtener
        // ============================================================
        [HttpGet("Obtener")]
        public async Task<IActionResult> Obtener()
        {
            var data = await _repo.GetAll();

            if (!data.Any())
                return NotFound("No existen detalles registrados.");

            return Ok(data);
        }

        // ============================================================
        // GET: api/SaleDetail/Obtener/ID
        // ============================================================
        [HttpGet("Obtener/{id}")]
        public async Task<IActionResult> ObtenerId(Guid id)
        {
            try
            {
                var detail = await _repo.GetById(id);
                return Ok(detail);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ============================================================
        // GET: api/SaleDetail/PorVenta/{saleId}
        // ============================================================
        [HttpGet("PorVenta/{saleId}")]
        public async Task<IActionResult> ObtenerPorVenta(Guid saleId)
        {
            var data = await _repo.GetBySaleId(saleId);
            return Ok(data);
        }

        // ============================================================
        // POST: api/SaleDetail/Crear
        // ============================================================
        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] Sale_Detail detail)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos.");

            var created = await _repo.Create(detail);
            return Ok(created);
        }

        // ============================================================
        // PUT: api/SaleDetail/Actualizar
        // ============================================================
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] Sale_Detail detail)
        {
            try
            {
                var updated = await _repo.Update(detail);
                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ============================================================
        // DELETE: api/SaleDetail/Eliminar/ID
        // ============================================================
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var deleted = await _repo.Delete(id);

            if (!deleted)
                return NotFound("Detalle no encontrado.");

            return Ok("Detalle eliminado correctamente.");
        }
    }
}
