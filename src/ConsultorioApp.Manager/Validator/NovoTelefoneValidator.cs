using ConsultorioApp.Shared.ModelView;
using FluentValidation;

namespace ConsultorioApp.Manager.Validator
{
    public class NovoTelefoneValidator : AbstractValidator<NovoTelefone>
    {
        public NovoTelefoneValidator()
        {
            RuleFor(p => p.Numero).Matches("[0-9][1-9]{10}").WithMessage("O telefone tem que ter o formato [2-9][0-9]{10}");
        }
    }
}
