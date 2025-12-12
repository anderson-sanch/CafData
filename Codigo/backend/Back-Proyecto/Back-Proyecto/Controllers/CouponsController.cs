using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICoupons _couponsRepository;

        public CouponsController(ICoupons couponsRepository)
        {
            _couponsRepository = couponsRepository;
        }

        // ============================================================
        // GET: api/Coupons/ObtenerCoupons
        // ============================================================
        [HttpGet("ObtenerCoupons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerCoupons()
        {
            var coupons = await _couponsRepository.GetCoupons();

            if (coupons == null || !coupons.Any())
                return NotFound("No existen cupones registrados.");

            return Ok(coupons);
        }

        // ============================================================
        // GET: api/Coupons/ObtenerCoupon/{id}
        // ============================================================
        [HttpGet("ObtenerCoupon/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerCoupon(Guid id)
        {
            var coupon = await _couponsRepository.GetCoupon_Id(id);

            if (coupon == null)
                return NotFound("Cupón no encontrado.");

            return Ok(coupon);
        }

        // ============================================================
        // POST: api/Coupons/CrearCoupon
        // ============================================================
        [HttpPost("CrearCoupon")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearCoupon([FromBody] Coupons coupon)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos.");

            coupon.Coupon_Id= Guid.NewGuid();
            coupon.Time_Used = 0; // Un cupón nuevo siempre empieza en 0

            var created = await _couponsRepository.CreateCoupon(coupon);

            return CreatedAtAction(nameof(ObtenerCoupon), new { id = created.Coupon_Id }, created);
        }

        // ============================================================
        // PUT: api/Coupons/ActualizarCoupon
        // ============================================================
        [HttpPut("ActualizarCoupon")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizarCoupon([FromBody] Coupons coupon)
        {
            var existing = await _couponsRepository.GetCoupon_Id(coupon.Coupon_Id);

            if (existing == null)
                return NotFound("El cupón no existe.");

            var updated = await _couponsRepository.UpdateCoupon(coupon);

            return Ok(updated);
        }

        // ============================================================
        // DELETE: api/Coupons/InactivarCoupon/{id}
        // ============================================================
        [HttpDelete("InactivarCoupon/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InactivarCoupon(Guid id)
        {
            var inactive = await _couponsRepository.InactiveCoupon(id);

            if (!inactive)
                return NotFound("El cupón no existe.");

            return Ok("Cupón inactivado correctamente.");
        }
    }
}
