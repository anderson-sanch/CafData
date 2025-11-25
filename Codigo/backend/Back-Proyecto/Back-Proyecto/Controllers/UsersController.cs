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
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
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
                var users = await _usersRepository.GetUsers();

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

        [HttpGet("TestConnection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                // Prueba simple usando el Repository
                var users = await _usersRepository.GetUsers();
                var userCount = users?.Count ?? 0;
                var hasUsers = userCount > 0;

                return Ok(new
                {
                    Success = true,
                    UserCount = userCount,
                    HasUsers = hasUsers,
                    Message = "Repository funciona correctamente"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Error = ex.Message,
                    InnerError = ex.InnerException?.Message,
                    Message = "Error en el Repository o base de datos"
                });
            }
        }
    }
}
