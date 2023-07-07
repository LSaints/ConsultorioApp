using ConsultorioApp.Manager.Mappings;
using ConsultorioApp.Shared.ModelView;

namespace ConsultorioApp.API.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void UseAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NovoClienteMappingProfile), typeof(AlteraClienteMappingProfile));
        }
    }
}
