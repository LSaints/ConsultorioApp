using ConsultorioApp.API.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.UseDependecyInjectionConfiguration();

        builder.Services.AddSwaggerGen();
        builder.Services.AddDatabaseConfiguration(builder.Configuration);

        builder.Services.UseAutoMapperConfiguration();

        builder.Services.UseFluentValidationConfiguration();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseDatabaseConfiguration();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}