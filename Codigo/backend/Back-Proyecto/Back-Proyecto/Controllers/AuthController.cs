using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Models.Enums;
using Back_Proyecto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly CafDataContext _context;

        public AuthController(
            IJwtService jwtService,
            CafDataContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }

        public class LoginRequest
        {
            public string UserName { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos.");

            //  Busca usuario REAL en BD
            var user = await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Username == request.UserName &&
                    u.Password == request.Password
                );



            if (user == null)
                return Unauthorized("Usuario o contraseña incorrectos.");

            string role = "User";

            // Genera token con datos REALES
            var token = _jwtService.GenerateToken(
                user.User_Id,
                user.Username,
                role
            );

            return Ok(new
            {
                Token = token,
                UserId = user.User_Id,
                User = user.Username,
                Role = role
            });
        }
    }
}
