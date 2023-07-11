using ConsultorioApp.Manager.Mappings;

namespace ConsultorioApp.API.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void UseAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NovoClienteMappingProfile), typeof(AlteraClienteMappingProfile));
            services.AddAutoMapper(typeof(NovoMedicoMappingProfile), typeof(AlteraMedicoMappingProfile));
        }
    }
}
