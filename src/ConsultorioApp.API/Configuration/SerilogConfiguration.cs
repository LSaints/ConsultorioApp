using Serilog;

namespace ConsultorioApp.API.Configuration
{
    public static class SerilogConfiguration
    {
        public static void UseSerilogConfiguration(this IHostBuilder host)
        {
            host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));
        }
    }
}
