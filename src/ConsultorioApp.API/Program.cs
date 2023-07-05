using ConsultorioApp.API.Configuration;
using ConsultorioApp.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConsultorioAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConsultorioConnection")));

FluentValidationConfiguration.UseFluentValidationConfig();
AutoMapperConfiguration.UseAutoMapperConfig();
DependecyInjectionConfig.UseDependecyInjectionConfiguration();

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
