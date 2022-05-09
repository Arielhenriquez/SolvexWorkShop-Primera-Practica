using AutoMapper;
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
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public static RegistroUsuario registro = new RegistroUsuario();
        public ClienteController(IMapper mapper , IConfiguration configuration)
        {
            _mapper = mapper;
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
        public IActionResult Login(RegistroUsuario registroUsuario)
        {
            if (registro.Email != registroUsuario.Email)
            {
                return BadRequest("Usuario no encontrado");
            }

            string token = CrearToken(registro);
            return Ok(token);
            
        }
        private string CrearToken(RegistroUsuario usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Email),
                new Claim("Password", usuario.Password)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken( 
                claims: claims,
                expires: DateTime.Now.AddDays(1), 
                signingCredentials: credencials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        [HttpPost]
        public IActionResult Add(ClienteRequest request)
        {
            Cliente cliente = _mapper.Map<Cliente>(request);
            return Ok();
        }
    }
}
