using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscounts _discounts;

        public DiscountsController(IDiscounts discounts)
        {
            _discounts = discounts;
        }

        [HttpGet("Obtener")]
        public async Task<ActionResult<List<Discounts>>> GetDiscounts()
        {
            return Ok(await _discounts.GetDiscounts());
        }

        [HttpGet("Obtener/{id}")]
        public async Task<ActionResult<Discounts>> GetDiscount(Guid id)
        {
            var discount = await _discounts.GetDiscountById(id);
            if (discount == null) return NotFound();
            return Ok(discount);
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Discounts>> CreateDiscount(Discounts discount)
        {
            var created = await _discounts.CreateDiscount(discount);
            return CreatedAtAction(nameof(GetDiscount), new { id = created.Discount_Id }, created);
        }

        [HttpPut("Actualizar")]
        public async Task<ActionResult<Discounts>> UpdateDiscount(Discounts discount)
        {
            var updated = await _discounts.UpdateDiscount(discount);
            return Ok(updated);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult> DeleteDiscount(Guid id)
        {
            var deleted = await _discounts.DeleteDiscount(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
