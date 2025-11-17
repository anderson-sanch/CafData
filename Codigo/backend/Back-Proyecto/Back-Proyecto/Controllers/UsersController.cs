using Back_Proyecto.Models;
using Back_Proyecto.Repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            usersRepository = usersRepository;
        }

        // =============================
        // GET: api/Users/ObtenerUsuarios
        // =============================
        [HttpGet("ObtenerUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            try
            {
                var users = await usersRepository.GetUsers();

                if (users == null || !users.Any())
                {
                    return NotFound("No se encontraron usuarios.");
                }

                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los usuarios.");
            }
        }

        // =====================================
        // GET: api/Users/ObtenerUsuarioPorId?id=GUID
        // =====================================
        [HttpGet("ObtenerUsuarioPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerUsuarioPorId(Guid id)
        {
            try
            {
                var user = await usersRepository.GetUserById(id);

                if (user == null)
                {
                    return NotFound("Usuario no encontrado.");
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el usuario.");
            }
        }

        // =============================
        // POST: api/Users/InsertarUsuario
        // =============================
        [HttpPost("InsertarUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarUsuario([FromBody] Users user)
        {
            try
            {
                var newUser = await usersRepository.CreateUser(user);

                if (newUser == null)
                {
                    return BadRequest("No se pudo insertar el usuario.");
                }

                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al insertar el usuario: {ex.Message}");
            }
        }

        // =============================
        // PUT: api/Users/ActualizarUsuario
        // =============================
        [HttpPut("ActualizarUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarUsuario([FromBody] Users user)
        {
            try
            {
                var result = await usersRepository.UpdateUser(user);

                if (result == null)
                {
                    return BadRequest("No se pudo actualizar el usuario.");
                }

                return Ok("Usuario actualizado correctamente.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el usuario.");
            }
        }

        // =============================
        // DELETE: api/Users/EliminarUsuario?id=GUID
        // =============================
        [HttpDelete("EliminarUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarUsuario(Guid id)
        {
            try
            {
                var result = await usersRepository.DeleteUser(id);

                if (!result)
                {
                    return BadRequest("No se pudo eliminar el usuario.");
                }

                return Ok("Usuario eliminado correctamente.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el usuario.");
            }
        }
    }
}
