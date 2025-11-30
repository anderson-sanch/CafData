using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissions _permissions;

        public PermissionsController(IPermissions permissions)
        {
            _permissions = permissions;
        }

        [HttpGet("ObtenerPermisos")]
        public async Task<IActionResult> ObtenerPermisos()
        {
            var data = await _permissions.GetPermissions();
            return Ok(data);
        }

        [HttpGet("ObtenerPermiso/{id}")]
        public async Task<IActionResult> ObtenerPermiso(Guid id)
        {
            var permission = await _permissions.GetPermission_Id(id);
            return Ok(permission);
        }

        [HttpPost("CrearPermiso")]
        public async Task<IActionResult> CrearPermiso([FromBody] Permissions permission)
        {
            var newPermission = await _permissions.CreatePermission(permission);
            return Ok(newPermission);
        }

        [HttpPut("ActualizarPermiso")]
        public async Task<IActionResult> ActualizarPermiso([FromBody] Permissions permission)
        {
            var updated = await _permissions.UpdatePermission(permission);
            return Ok(updated);
        }

        [HttpDelete("EliminarPermiso/{id}")]
        public async Task<IActionResult> EliminarPermiso(Guid id)
        {
            var deleted = await _permissions.DeletePermission(id);

            if (!deleted)
                return NotFound("El permiso no existe");

            return Ok("Permiso eliminado");
        }
    }
}
