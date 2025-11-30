using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts _productsRepository;

        public ProductsController(IProducts productsRepository)
        {
            _productsRepository = productsRepository;
        }

        // GET: api/Products/Obtener
        [HttpGet("Obtener")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productsRepository.GetProducts();
            return Ok(products);
        }

        // GET: api/Products/Obtener/{id}
        [HttpGet("Obtener/{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _productsRepository.GetProduct(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST: api/Products/Crear
        [HttpPost("Crear")]
        public async Task<IActionResult> CreateProduct([FromBody] Products product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdProduct = await _productsRepository.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Product_Id }, createdProduct);
        }

        // PUT: api/Products/Actualizar
        [HttpPut("Actualizar")]
        public async Task<IActionResult> UpdateProduct([FromBody] Products product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedProduct = await _productsRepository.UpdateProduct(product);
            if (updatedProduct == null) return NotFound();

            return Ok(updatedProduct);
        }

        // DELETE: api/Products/Eliminar/{id}
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var deleted = await _productsRepository.DeleteProduct(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
