using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoles _roles;

        public RolesController(IRoles roles)
        {
            _roles = roles;
        }

        [HttpGet("ObtenerRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var data = await _roles.GetRoles();
            return Ok(data);
        }

        [HttpGet("ObtenerRol/{id}")]
        public async Task<IActionResult> GetRol(Guid id)
        {
            var role = await _roles.GetRol_Id(id);
            return Ok(role);
        }

        [HttpPost("CrearRol")]
        public async Task<IActionResult> CrearRol([FromBody] Roles role)
        {
            var newRole = await _roles.CreateRol(role);
            return Ok(newRole);
        }

        [HttpPut("ActualizarRol")]
        public async Task<IActionResult> ActualizarRol([FromBody] Roles role)
        {
            var update = await _roles.UpdateRol(role);
            return Ok(update);
        }

        [HttpDelete("EliminarRol/{id}")]
        public async Task<IActionResult> EliminarRol(Guid id)
        {
            var deleted = await _roles.DeleteRole(id);

            if (!deleted)
                return NotFound();

            return Ok("Rol eliminado");
        }
    }
}
