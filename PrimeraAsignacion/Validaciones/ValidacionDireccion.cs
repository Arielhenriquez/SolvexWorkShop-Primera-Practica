using FluentValidation;
using PrimeraAsignacion.Models;

namespace PrimeraAsignacion.Validaciones
{
    public class ValidacionDireccion : AbstractValidator<DireccionCliente>
    {
        public ValidacionDireccion()
        {
            RuleFor(address => address.ZipCode).MaximumLength(5).MinimumLength(5) 
                .WithMessage("El codigo postal no puede ser menor a 5 digitos");

            RuleFor(address => address.HouseNumber).MaximumLength(2)
                .WithMessage("El numero de casa no puede ser menor a 2 digitos");
        }
    }
}
