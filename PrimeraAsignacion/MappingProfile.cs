using AutoMapper;
using PrimeraAsignacion.Models;

namespace PrimeraAsignacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteRequest, Cliente>()
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.NombreCompleto))

                .ForMember(destination => destination.LastName, o => o.MapFrom(source => source.Apellidos))

                .ForMember(destination => destination.Age, o => o.MapFrom(source => source.Edad))

                .ForMember(destination => destination.ClientAddress, o => o.MapFrom(source => source.DireccionCliente))

                .ForMember(destination => destination.BirthDate, o => o.MapFrom(source => source.FechaNacimiento));
        }
    }
}
