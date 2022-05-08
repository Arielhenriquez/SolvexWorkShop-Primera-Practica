using FluentValidation;
using PrimeraAsignacion.Models;

namespace PrimeraAsignacion.Validaciones
{
    public class ValidacionCliente : AbstractValidator<ClienteRequest>
    {
        public ValidacionCliente()
        {
            RuleFor(name => name.NombreCompleto).NotNull()
                .NotEmpty()
                .WithMessage("El campo no puede estar vacio");

            RuleFor(surName => surName.Apellidos).NotEmpty()
                .NotNull().WithMessage("Este campo es obligatorio");

            RuleFor(age => age.Edad)
                .NotEmpty()
                .GreaterThanOrEqualTo(18)
                .WithMessage("Su edad debe ser mayor a 18");

            RuleFor(address => address.DireccionCliente).SetValidator(new ValidacionDireccion());

            RuleFor(model => model.FechaNacimiento)
            .GreaterThanOrEqualTo(DateTime.Today.AddYears(-18))
            .WithMessage("Su edad debe ser mayor a 18")
            .LessThanOrEqualTo(DateTime.Today) 
            .WithMessage("Fecha invalida");

        }

    }
}
