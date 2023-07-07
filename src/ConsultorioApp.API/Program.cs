using ConsultorioApp.API.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilogConfiguration();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.UseAutoMapperConfiguration();

builder.Services.UseDependecyInjectionConfiguration();

builder.Services.UseFluentValidationConfiguration();

var app = builder.Build();

app.UseExceptionHandler("/error");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseDatabaseConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
