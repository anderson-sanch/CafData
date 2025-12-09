using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMovementController : ControllerBase
    {
        private readonly IInventoryMovement _repo;

        public InventoryMovementController(IInventoryMovement repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _repo.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryMovement movement)
        {
            var result = await _repo.Create(movement);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InventoryMovement movement)
        {
            var result = await _repo.Update(movement);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _repo.Delete(id);
            return ok ? Ok() : NotFound();
        }
    }
}
