using ConsultorioApp.Data.Context;
using ConsultorioApp.Data.Implementation;
using ConsultorioApp.Data.Repository;
using ConsultorioApp.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<ConsultorioAppContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConsultorioConnection")));

        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        builder.Services.AddScoped<IClienteManager, ClienteManager>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}