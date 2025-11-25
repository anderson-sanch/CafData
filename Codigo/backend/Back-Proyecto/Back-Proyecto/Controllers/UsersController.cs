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
    }
}
