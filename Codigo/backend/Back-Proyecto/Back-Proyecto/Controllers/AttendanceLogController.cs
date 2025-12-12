using Back_Proyecto.Models;
using Back_Proyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceLogController : ControllerBase
    {
        private readonly IAttendanceLogService _service;

        public AttendanceLogController(IAttendanceLogService service)
        {
            _service = service;
        }

        // ============================================================
        // GET: api/AttendanceLog/ObtenerAsistencias
        // ============================================================
        [HttpGet("ObtenerAsistencias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerAsistencias()
        {
            var logs = await _service.GetAllAsync();

            if (logs == null || !logs.Any())
                return NotFound("No existen registros de asistencias.");

            return Ok(logs);
        }

        // ============================================================
        // GET: api/AttendanceLog/ObtenerAsistencia/{id}
        // ============================================================
        [HttpGet("ObtenerAsistencia/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerAsistencia(Guid id)
        {
            var log = await _service.GetByIdAsync(id);

            if (log == null)
                return NotFound("La asistencia seleccionada no existe.");

            return Ok(log);
        }

        // ============================================================
        // POST: api/AttendanceLog/CrearAsistencia
        // ============================================================
        [HttpPost("CrearAsistencia")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearAsistencia([FromBody] Attendance_Log log)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos.");

            var created = await _service.CreateAsync(log);

            return CreatedAtAction(nameof(ObtenerAsistencia),
                new { id = created.Attendance_Id }, created);
        }

        // ============================================================
        // PUT: api/AttendanceLog/ActualizarAsistencia/{id}
        // ============================================================
        [HttpPut("ActualizarAsistencia/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizarAsistencia(Guid id, [FromBody] Attendance_Log log)
        {
            var exists = await _service.GetByIdAsync(id);

            if (exists == null)
                return NotFound("La asistencia no existe.");

            var updated = await _service.UpdateAsync(id, log);

            return Ok(updated);
        }

        // ============================================================
        // DELETE: api/AttendanceLog/EliminarAsistencia/{id}
        // ============================================================
        [HttpDelete("EliminarAsistencia/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarAsistencia(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound("La asistencia no existe.");

            return Ok("Asistencia eliminada correctamente.");
        }
    }
}
