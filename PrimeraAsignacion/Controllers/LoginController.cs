using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrimeraAsignacion.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PrimeraAsignacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public static RegistroUsuario registro = new RegistroUsuario();

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("Registro")]
        public IActionResult Registro(RegistroUsuario registroUsuario)
        {
            registro.Email = registroUsuario.Email;
            registro.Password = registroUsuario.Password;
            return Ok(registro);
        }

        [HttpPost("Login")]
        public IActionResult Login(RegistroUsuario usuario)
        {
            if (registro.Email != usuario.Email)
            {
                return BadRequest("Usuario no encontrado");
            }

            if (registro.Password != usuario.Password)
            {
                return BadRequest("Contraseña incorrecta");
            }
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Name, usuario.Email),
                new Claim("Password", usuario.Password)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwt.key));
            var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credencials);
            return Ok(new JwtSecurityTokenHandler().WriteToken(token)); 
        }
    }
}
