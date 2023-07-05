using ConsultorioApp.Manager.Mappings;

namespace ConsultorioApp.API.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void UseAutoMapperConfig() 
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddAutoMapper(typeof(NovoClienteMappingProfile), typeof(AlteraClienteMappingProfile));
        }
    }
}
