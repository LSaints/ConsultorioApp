﻿using ConsultorioApp.Shared.ModelView;
using FluentValidation;

namespace ConsultorioApp.Manager.Validator
{
    public class NovoClienteValidator : AbstractValidator<NovoCliente>
    {
        public NovoClienteValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(10).MaximumLength(150);
            RuleFor(x => x.DataNascimento).NotEmpty().NotNull().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
            RuleFor(x => x.Documento).NotEmpty().NotNull().MinimumLength(4).MaximumLength(14);
            RuleFor(x => x.Telefones).NotEmpty().NotNull();
            RuleFor(x => x.Sexo).NotNull();
            RuleFor(x => x.Endereco).SetValidator(new NovoEnderecoValidator());
        }
    }
}
