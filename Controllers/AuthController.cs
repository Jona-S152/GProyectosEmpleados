using GProyectosEmpleados.Models;
using GProyectosEmpleados.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GProyectosEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        AuthController(DataContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        [HttpPost]
        public IActionResult LoginJWT(LoginDTO loginDTO)
        {
            var empleadoAutenticado = Login(loginDTO);

            if (empleadoAutenticado == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new
                {
                    message = "Credenciales incorrectas"
                });
            }

            string token = GenerateToken(empleadoAutenticado);

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = token
            });
        }

        private Empleado Login(LoginDTO loginDTO)
        {
            var usuario = _context.Empleados.FirstOrDefault(
                e => e.CorreoElectronico.ToLower() == loginDTO.CorreoElectronico.ToLower() &&
                e.NumeroTelefono.ToLower() == loginDTO.NumeroTelefono.ToLower()
                );

            return usuario;
        }

        private string GenerateToken(Empleado empleado)
        {
            // Credenciales
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, empleado.CorreoElectronico),
                new Claim(ClaimTypes.Role, empleado.Cargo)
            };

            // Token
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token).ToString();
        }
    }
}
