using ConsultorioApp.Shared.ModelView;
using FluentValidation;

namespace ConsultorioApp.Manager.Validator
{
    public class NovoEnderecoValidator : AbstractValidator<NovoEndereco>
    {
        public NovoEnderecoValidator()
        {
            RuleFor(c => c.Cidade).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(c => c.Estado).NotNull();
        }
    }
}
