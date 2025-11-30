using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesPermissionsController : ControllerBase
    {
        private readonly IRolesPermissions _repo;

        public RolesPermissionsController(IRolesPermissions repo)
        {
            _repo = repo;
        }

        // ================================
        // GET: api/RolesPermissions
        // ================================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repo.GetRoles_Permissions();
            if (items == null || !items.Any())
                return NotFound("No existen relaciones de Roles con Permisos.");

            return Ok(items);
        }

        // ========================================
        // GET: api/RolesPermissions/{rolId}/{permId}
        // ========================================
        [HttpGet("{rolId:guid}/{permissionId:guid}")]
        public async Task<IActionResult> Get(Guid rolId, Guid permissionId)
        {
            var item = await _repo.GetRole_Permission(rolId, permissionId);

            if (item == null)
                return NotFound("Relación no encontrada.");

            return Ok(item);
        }

        // ================================
        // POST: api/RolesPermissions
        // ================================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolesPermissions rp)
        {
            if (rp == null)
                return BadRequest("Datos inválidos.");

            var created = await _repo.CreateRole_Permission(rp);

            return Ok(created);
        }

        // ========================================
        // DELETE: api/RolesPermissions/{rolId}/{permId}
        // ========================================
        [HttpDelete("{rolId:guid}/{permissionId:guid}")]
        public async Task<IActionResult> Delete(Guid rolId, Guid permissionId)
        {
            var deleted = await _repo.DeleteRole_Permission(rolId, permissionId);

            if (!deleted)
                return NotFound("No se encontró la relación para eliminar.");

            return Ok("Relación eliminada correctamente.");
        }
    }
}
