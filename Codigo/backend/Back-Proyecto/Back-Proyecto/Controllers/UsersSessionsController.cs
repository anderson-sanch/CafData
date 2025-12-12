using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSessionsController : ControllerBase
    {
        private readonly IUsers_Sessions _sessionsRepo;

        public UserSessionsController(IUsers_Sessions sessionsRepo)
        {
            _sessionsRepo = sessionsRepo;
        }

        // ============================================================
        // GET: api/UserSessions/Obtener
        // ============================================================
        [HttpGet("Obtener")]
        public async Task<IActionResult> Obtener()
        {
            var data = await _sessionsRepo.GetUsers_Sessions();

            if (data == null || !data.Any())
                return NotFound("No existen sesiones registradas.");

            return Ok(data);
        }

        // ============================================================
        // GET: api/UserSessions/Obtener/{id}
        // ============================================================
        [HttpGet("Obtener/{id}")]
        public async Task<IActionResult> Obtener_Id(Guid id)
        {
            try
            {
                var session = await _sessionsRepo.GetUser_Session_Id(id);
                return Ok(session);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ============================================================
        // POST: api/UserSessions/Crear
        // ============================================================
        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] User_Sessions session)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos.");

            session.Id_Session = Guid.NewGuid();

            try
            {
                var created = await _sessionsRepo.CreateUser_Session(session);
                return CreatedAtAction(nameof(Obtener_Id), new { id = created.Id_Session }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ============================================================
        // PUT: api/UserSessions/Actualizar
        // ============================================================
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] User_Sessions session)
        {
            try
            {
                var updated = await _sessionsRepo.UpdateUser_Session(session);
                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ============================================================
        // DELETE: api/UserSessions/Eliminar/{id}
        // ============================================================
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var deleted = await _sessionsRepo.DeleteUser_Session(id);

            if (!deleted)
                return NotFound("No se encontró la sesión para eliminar.");

            return Ok("Sesión eliminada correctamente.");
        }
    }
}
