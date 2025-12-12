using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISales _salesRepo;

        public SalesController(ISales salesRepo)
        {
            _salesRepo = salesRepo;
        }

        // ============================================================
        // GET: api/Sales/Obtener
        // ============================================================
        [HttpGet("Obtener")]
        public async Task<IActionResult> Obtener()
        {
            var sales = await _salesRepo.GetSales();

            if (!sales.Any())
                return NotFound("No existen ventas registradas.");

            return Ok(sales);
        }

        // ============================================================
        // GET: api/Sales/Obtener/{id}
        // ============================================================
        [HttpGet("Obtener/{id}")]
        public async Task<IActionResult> Obtener_Id(Guid id)
        {
            try
            {
                var sale = await _salesRepo.GetSale_Id(id);
                return Ok(sale);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ============================================================
        // POST: api/Sales/Crear
        // ============================================================
        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] Sales sale)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos.");

            try
            {
                var created = await _salesRepo.CreateSale(sale);
                return CreatedAtAction(nameof(Obtener_Id), new { id = created.Sale_Id }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ============================================================
        // PUT: api/Sales/Actualizar
        // ============================================================
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] Sales sale)
        {
            try
            {
                var updated = await _salesRepo.UpdateSale(sale);
                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ============================================================
        // DELETE: api/Sales/Eliminar/{id}
        // ============================================================
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var deleted = await _salesRepo.DeleteSale(id);

            if (!deleted)
                return NotFound("No se encontró la venta para eliminar.");

            return Ok("Venta eliminada correctamente.");
        }

    }
}