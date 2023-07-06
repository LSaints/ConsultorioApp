using ConsultorioApp.Manager.Validator;
using FluentValidation.AspNetCore;
using System.Globalization;

namespace ConsultorioApp.API.Configuration
{
    public static class FluentValidationConfiguration
    {
        public static void UseFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
               .AddFluentValidation(p =>
               {
                   p.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                   p.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                   p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
               });
        }
    }
}
