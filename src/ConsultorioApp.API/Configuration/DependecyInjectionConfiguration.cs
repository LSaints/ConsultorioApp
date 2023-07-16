using ConsultorioApp.Data.Implementation;
using ConsultorioApp.Data.Repository;
using ConsultorioApp.Manager.Implementation;
using ConsultorioApp.Manager.Interfaces.Managers;
using ConsultorioApp.Manager.Interfaces.Repositories;

namespace ConsultorioApp.API.Configuration
{
    public static class DependecyInjectionConfiguration
    {
        public static void UseDependecyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();
            services.AddScoped<IMedicoManager, MedicoManager>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
        }
    }
}
