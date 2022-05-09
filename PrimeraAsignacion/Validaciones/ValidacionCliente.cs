using FluentValidation;
using PrimeraAsignacion.Models;

namespace PrimeraAsignacion.Validaciones
{
    public class ValidacionCliente : AbstractValidator<ClienteRequest>
    {
        public ValidacionCliente()
        {
            RuleFor(name => name.NombreCompleto).NotNull()
                .MinimumLength(2)
                .WithMessage("El campo debe contener mas de un caracter");

            RuleFor(surName => surName.Apellidos).NotEmpty().MaximumLength(20)
                .WithMessage("Este campo debe contener menos de 20 caracteres");

            RuleFor(age => age.Edad)
                .NotEmpty()
                .GreaterThanOrEqualTo(18)
                .WithMessage("Su edad debe ser mayor a 18");

            RuleFor(address => address.DireccionCliente).SetValidator(new ValidacionDireccion());

            RuleFor(model => model.FechaNacimiento)
            .LessThanOrEqualTo(DateTime.Today.AddYears(-18))
            .WithMessage("Su edad debe ser mayor a 18")
            .LessThanOrEqualTo(DateTime.Today) 
            .WithMessage("Fecha invalida");

        }

    }
}
