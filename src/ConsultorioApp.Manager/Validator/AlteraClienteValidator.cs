using ConsultorioApp.Shared.ModelView;
using FluentValidation;
using System.Data;

namespace ConsultorioApp.Manager.Validator
{
    public class AlteraClienteValidator : AbstractValidator<AlteraCliente>
    {
        public AlteraClienteValidator()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty().GreaterThan(0);
            Include(new NovoClienteValidator());
        }
    }
}
