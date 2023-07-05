﻿using ConsultorioApp.Core.Domain;
using FluentValidation;

namespace ConsultorioApp.Manager.Validator
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(10).MaximumLength(150);
            RuleFor(x => x.DataNascimento).NotEmpty().NotNull().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
            RuleFor(x => x.Documento).NotEmpty().NotNull().MinimumLength(4).MaximumLength(14);
            RuleFor(x => x.Telefone).NotEmpty().NotNull().Matches("[2-9][6-9]{10}").WithMessage("O telefone tem que ter o formato [2-9][0-9]{10}");
            RuleFor(x => x.Sexo).NotEmpty().NotNull().Must(IsMorF).WithMessage("Sexo precisa ser M ou F");
        }

        private bool IsMorF(char sexo)
        {
            return sexo == 'M' || sexo == 'F';
        }
    }
}