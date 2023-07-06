using ConsultorioApp.Data.Implementation;
using ConsultorioApp.Data.Repository;
using ConsultorioApp.Manager.Interfaces;

namespace ConsultorioApp.API.Configuration
{
    public static class DependecyInjectionConfiguration
    {
        public static void UseDependecyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();
        }
    }
}
