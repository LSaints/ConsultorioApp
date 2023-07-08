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
                .AddNewtonsoftJson(p => p.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
               .AddFluentValidation(p =>
               {
                   p.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                   p.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                   p.RegisterValidatorsFromAssemblyContaining<NovoEnderecoValidator>();
                   p.RegisterValidatorsFromAssemblyContaining<NovoTelefoneValidator>();
                   p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
               });
        }
    }
}
