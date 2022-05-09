namespace PrimeraAsignacion.Models
{
    public class RegistroUsuario
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
    }

    public class Jwt
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
