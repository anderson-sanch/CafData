using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompany _companyRepository;

        public CompanyController(ICompany companyRepository)
        {
            _companyRepository = companyRepository;
        }

        // ============================================================
        // GET: api/Company/ObtenerCompany
        // ============================================================
        [HttpGet("ObtenerCompany")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerCompany()
        {
            var companies = await _companyRepository.GetCompany();

            if (companies == null || !companies.Any())
                return NotFound("No existen registros de empresa.");

            return Ok(companies);
        }

        // ============================================================
        // GET: api/Company/ObtenerCompany/{id}
        // ============================================================
        [HttpGet("ObtenerCompany/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerCompany_Id(Guid id)
        {
            var company = await _companyRepository.GetCompany_Id(id);

            if (company == null)
                return NotFound("La empresa no existe.");

            return Ok(company);
        }

        // ============================================================
        // POST: api/Company/CrearCompany
        // ============================================================
        [HttpPost("CrearCompany")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearCompany([FromBody] Company company)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos.");

            company.Company_Id = Guid.NewGuid();

            var created = await _companyRepository.CreateCompany(company);

            return CreatedAtAction(nameof(ObtenerCompany_Id), new { id = created.Company_Id }, created);
        }

        // ============================================================
        // PUT: api/Company/ActualizarCompany
        // ============================================================
        [HttpPut("ActualizarCompany")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizarCompany([FromBody] Company company)
        {
            var exists = await _companyRepository.GetCompany_Id(company.Company_Id);

            if (exists == null)
                return NotFound("La empresa no existe.");

            var updated = await _companyRepository.UpdateCompany(company);

            return Ok(updated);
        }

        // ============================================================
        // DELETE: api/Company/InactivarCompany/{id}
        // ============================================================
        [HttpDelete("InactivarCompany/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InactivarCompany(Guid id)
        {
            var inactive = await _companyRepository.InactiveCompany(id);

            if (!inactive)
                return NotFound("La empresa no existe.");

            return Ok("Empresa inactivada correctamente.");
        }
    }
}
