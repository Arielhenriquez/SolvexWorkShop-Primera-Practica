namespace PrimeraAsignacion.Models
{
    public class ClienteRequest
    {
        public int Id { get; set; }
        public int Id2 { get; set; }
        public int Id3 { get; set; }
        public int Id4 { get; set; }
        public int Id5 { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Apellidos { get; set; }
        public int Edad { get; set; }
        public DireccionCliente? DireccionCliente { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
