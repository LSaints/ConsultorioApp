using ConsultorioApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.API.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConsultorioAppContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConsultorioConnection")));
        }

        public static void UseDatabaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ConsultorioAppContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}
