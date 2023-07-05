using ConsultorioApp.Data.Context;
using ConsultorioApp.Data.Implementation;
using ConsultorioApp.Data.Repository;
using ConsultorioApp.Manager.Interfaces;
using ConsultorioApp.Manager.Validator;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConsultorioAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConsultorioConnection")));

builder.Services.AddControllers()
    .AddFluentValidation(p =>
    {
        p.RegisterValidatorsFromAssemblyContaining<ClienteValidator>();
        p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
    });

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
