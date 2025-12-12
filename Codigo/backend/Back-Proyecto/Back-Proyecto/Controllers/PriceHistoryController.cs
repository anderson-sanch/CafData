using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceHistoryController : ControllerBase
    {
        private readonly IPriceHistory _historyRepository;

        public PriceHistoryController(IPriceHistory historyRepository)
        {
            _historyRepository = historyRepository;
        }

        [HttpGet("Obtener")]
        public async Task<IActionResult> Obtener()
        {
            var data = await _historyRepository.GetPriceHistory();

            if (!data.Any())
                return NotFound("No existe historial de precios registrado.");

            return Ok(data);
        }

        [HttpGet("Obtener/{id}")]
        public async Task<IActionResult> Obtener_Id(Guid id)
        {
            try
            {
                var record = await _historyRepository.GetPriceHistory_Id(id);
                return Ok(record);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] Price_History history)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos.");

            history.History_Id = Guid.NewGuid();
            history.Change_Date = DateTime.UtcNow;

            var created = await _historyRepository.CreatePriceHistory(history);

            return CreatedAtAction(nameof(Obtener_Id), new { id = created.History_Id }, created);
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] Price_History history)
        {
            try
            {
                var updated = await _historyRepository.UpdatePriceHistory(history);
                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var deleted = await _historyRepository.DeletePriceHistory(id);

            if (!deleted)
                return NotFound("No se encontró el registro para eliminar.");

            return Ok("Historial eliminado correctamente.");
        }
    }
}
