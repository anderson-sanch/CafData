using Back_Proyecto.Models;
using Back_Proyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserScheduleController : ControllerBase
    {
        private readonly IUserSheduleService _service;

        public UserScheduleController(IUserSheduleService service)
        {
            _service = service;
        }

        // ============================================================
        // GET: api/UserSchedule/ObtenerHorarios
        // ============================================================
        [HttpGet("ObtenerHorarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerHorarios()
        {
            var schedules = await _service.GetAllAsync();

            if (schedules == null || !schedules.Any())
                return NotFound("No existen horarios registrados.");

            return Ok(schedules);
        }

        // ============================================================
        // GET: api/UserSchedule/ObtenerHorario/{id}
        // ============================================================
        [HttpGet("ObtenerHorario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerHorario(Guid id)
        {
            var schedule = await _service.GetByIdAsync(id);

            if (schedule == null)
                return NotFound("El horario no existe.");

            return Ok(schedule);
        }

        // ============================================================
        // POST: api/UserSchedule/CrearHorario
        // ============================================================
        [HttpPost("CrearHorario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearHorario([FromBody] User_Schedule schedule)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos.");

            var created = await _service.AddAsync(schedule);

            return CreatedAtAction(nameof(ObtenerHorario),
                new { id = created.Schedules_Id },
                created);
        }

        // ============================================================
        // PUT: api/UserSchedule/ActualizarHorario/{id}
        // ============================================================
        [HttpPut("ActualizarHorario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizarHorario(Guid id, [FromBody] User_Schedule schedule)
        {
            var exists = await _service.GetByIdAsync(id);

            if (exists == null)
                return NotFound("El horario no existe.");

            var updated = await _service.UpdateAsync(id, schedule);

            return Ok(updated);
        }

        // ============================================================
        // DELETE: api/UserSchedule/EliminarHorario/{id}
        // ============================================================
        [HttpDelete("EliminarHorario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarHorario(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound("El horario no existe o ya fue eliminado.");

            return Ok("Horario eliminado correctamente.");
        }
    }
}
