using ConsultorioApp.Data.Implementation;
using ConsultorioApp.Data.Repository;
using ConsultorioApp.Manager.Interfaces;

namespace ConsultorioApp.API.Configuration
{
    public static class DependecyInjectionConfig
    {

        public static void UseDependecyInjectionConfiguration()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IClienteManager, ClienteManager>();
        }
    }
}
