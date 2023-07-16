using ConsultorioApp.Manager.Validator;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ConsultorioApp.API.Configuration
{
    public static class FluentValidationConfiguration
    {
        public static void UseFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(p => 
                {
                    p.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    p.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddJsonOptions(p => 
                {
                p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
               .AddFluentValidation(p =>
               {
                   p.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                   p.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                   p.RegisterValidatorsFromAssemblyContaining<NovoEnderecoValidator>();
                   p.RegisterValidatorsFromAssemblyContaining<NovoTelefoneValidator>();
                   p.RegisterValidatorsFromAssemblyContaining<NovoMedicoValidator>();
                   p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
               });
        }
    }
}
