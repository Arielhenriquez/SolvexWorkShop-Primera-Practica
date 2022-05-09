using FluentValidation;
using PrimeraAsignacion.Models;

namespace PrimeraAsignacion.Validaciones
{
    public class ValidacionRegistro : AbstractValidator<RegistroUsuario>
    {
        public ValidacionRegistro()
        {
            RuleFor(email => email.Email).EmailAddress().WithMessage("Ingrese un correo valido");
            RuleFor(password => password.Password).NotEmpty().MaximumLength(10);
        }
    }
}
