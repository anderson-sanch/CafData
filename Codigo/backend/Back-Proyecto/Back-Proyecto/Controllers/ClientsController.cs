using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientsController(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        // =======================================
        // GET: api/Clients/ObtenerClientes
        // =======================================
        [HttpGet("ObtenerClientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerClientes()
        {
            var clients = await _clientsRepository.GetClients();

            if (clients == null || !clients.Any())
                return NotFound("No se encontraron clientes.");

            return Ok(clients);
        }

        // =======================================
        // GET: api/Clients/ObtenerCliente/{id}
        // =======================================
        [HttpGet("ObtenerCliente/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerCliente(Guid id)
        {
            var client = await _clientsRepository.GetClientById(id);

            if (client == null)
                return NotFound("Cliente no encontrado.");

            return Ok(client);
        }

        // =======================================
        // POST: api/Clients/CrearCliente
        // =======================================
        [HttpPost("CrearCliente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearCliente([FromBody] Clients client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _clientsRepository.CreateClient(client);

            return CreatedAtAction(nameof(ObtenerCliente), new { id = created.Client_Id }, created);
        }

        // =======================================
        // PUT: api/Clients/ActualizarCliente
        // =======================================
        [HttpPut("ActualizarCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizarCliente([FromBody] Clients client)
        {
            var updated = await _clientsRepository.UpdateClient(client);

            if (updated == null)
                return NotFound("Cliente no encontrado para actualizar.");

            return Ok(updated);
        }

        // =======================================
        // DELETE: api/Clients/EliminarCliente/{id}
        // =======================================
        [HttpDelete("EliminarCliente/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarCliente(Guid id)
        {
            var deleted = await _clientsRepository.DeleteClient(id);

            if (!deleted)
                return NotFound("Cliente no encontrado para eliminar.");

            return Ok("Cliente eliminado correctamente.");
        }
    }
}
