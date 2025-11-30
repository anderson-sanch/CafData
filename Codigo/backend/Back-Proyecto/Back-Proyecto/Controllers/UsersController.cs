using Back_Proyecto.Models;
using Back_Proyecto.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        // ============================================================
        // GET: api/Users/ObtenerUsuarios
        // ============================================================
        [HttpGet("ObtenerUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _usersRepository.GetUsers();

                if (users == null || !users.Any())
                    return NotFound("No se encontraron usuarios.");

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // ============================================================
        // GET: api/Users/ObtenerUsuario/{id}
        // ============================================================
        [HttpGet("ObtenerUsuario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var user = await _usersRepository.GetUserById(id);

                if (user == null)
                    return NotFound("Usuario no encontrado.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // ============================================================
        // POST: api/Users/CrearUsuario
        // ============================================================
        [HttpPost("CrearUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] Users model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Datos inválidos.");

                var created = await _usersRepository.CreateUser(model);

                return CreatedAtAction(nameof(GetById), new { id = created.User_Id }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // ============================================================
        // PUT: api/Users/ActualizarUsuario
        // ============================================================
        [HttpPut("ActualizarUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] Users model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Datos inválidos.");

                var updated = await _usersRepository.UpdateUser(model);

                if (updated == null)
                    return NotFound("Usuario no encontrado.");

                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // ============================================================
        // DELETE: api/Users/EliminarUsuario/{id}
        // ============================================================
        [HttpDelete("EliminarUsuario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleted = await _usersRepository.DeleteUser(id);

                if (!deleted)
                    return NotFound("Usuario no encontrado.");

                return Ok("Usuario eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
