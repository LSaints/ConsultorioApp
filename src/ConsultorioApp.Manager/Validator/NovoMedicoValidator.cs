using ConsultorioApp.Manager.Interfaces.Repositories;
using ConsultorioApp.Shared.ModelView;
using FluentValidation;

namespace ConsultorioApp.Manager.Validator
{
    public class NovoMedicoValidator : AbstractValidator<NovoMedico>
    {
        public NovoMedicoValidator(IEspecialidadeRepository repository)
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(p => p.CRM).NotNull().NotEmpty().GreaterThan(0);
            // RuleFor(p => p.Especialidades).SetValidator(new ReferenciaEspecialidadeValidator(repository));
        }
    }
}
