namespace PrimeraAsignacion.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public int Id2 { get; set; }
        public int Id3 { get; set; }
        public int Id4 { get; set; }
        public int Id5 { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public DireccionCliente? ClientAddress { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
