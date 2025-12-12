using Back_Proyecto.Models;
using Back_Proyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemLogController : ControllerBase
    {
        private readonly ISystemLogService _service;

        public SystemLogController(ISystemLogService service)
        {
            _service = service;
        }

        // ============================================================
        // GET: api/SystemLog/ObtenerLogs
        // ============================================================
        [HttpGet("ObtenerLogs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerLogs()
        {
            var logs = await _service.GetAllAsync();

            if (logs == null || !logs.Any())
                return NotFound("No existen registros de logs del sistema.");

            return Ok(logs);
        }

        // ============================================================
        // GET: api/SystemLog/ObtenerLog/{id}
        // ============================================================
        [HttpGet("ObtenerLog/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerLog(Guid id)
        {
            var log = await _service.GetByIdAsync(id);

            if (log == null)
                return NotFound("El registro del sistema no existe.");

            return Ok(log);
        }

        // ============================================================
        // POST: api/SystemLog/CrearLog
        // ============================================================
        [HttpPost("CrearLog")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearLog([FromBody] System_Log log)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos.");

            var created = await _service.CreateAsync(log);

            return CreatedAtAction(nameof(ObtenerLog),
                new { id = created.Id_Logs },
                created);
        }

        // ============================================================
        // PUT: api/SystemLog/ActualizarLog/{id}
        // ============================================================
        [HttpPut("ActualizarLog/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizarLog(Guid id, [FromBody] System_Log log)
        {
            var exists = await _service.GetByIdAsync(id);

            if (exists == null)
                return NotFound("El registro a actualizar no existe.");

            var updated = await _service.UpdateAsync(id, log);

            return Ok(updated);
        }

        // ============================================================
        // DELETE: api/SystemLog/EliminarLog/{id}
        // ============================================================
        [HttpDelete("EliminarLog/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarLog(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound("El registro no existe o ya fue eliminado.");

            return Ok("Registro del sistema eliminado correctamente.");
        }
    }
}
