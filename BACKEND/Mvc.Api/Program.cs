using DbModel.demoDb;
using Microsoft.EntityFrameworkCore;
using Mvc.Bussnies.Persona;
using Mvc.Bussnies.PersonaCorreo;
using Mvc.Bussnies.PersonaDireccion;
using Mvc.Bussnies.PersonaEmpleo;
using Mvc.Repository.PersonaRepo.Contratos;
using Mvc.Repository.PersonaRepo.Implementacion;
using Mvc.Repository.PersonaCorreoRepo.Contratos;
using Mvc.Repository.PersonaCorreoRepo.Implementacion;
using Mvc.Repository.PersonaDireccionRepo.Contratos;
using Mvc.Repository.PersonaDireccionRepo.Implementacion;
using Mvc.Repository.PersonaEmpleoRepo.Contratos;
using Mvc.Repository.PersonaEmpleoRepo.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar la conexión a la base de datos
builder.Services.AddDbContext<_demoContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("demoDb");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Inyección de dependencias - Repositories
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IPersonaCorreoRepository, PersonaCorreoRepository>();
builder.Services.AddScoped<IPersonaDireccionRepository, PersonaDireccionRepository>();
builder.Services.AddScoped<IPersonaEmpleoRepository, PersonaEmpleoRepository>();

// Inyección de dependencias - Business Logic
builder.Services.AddScoped<IPersonaBussnies, PersonaBussnies>();
builder.Services.AddScoped<IPersonaCorreoBussnies, PersonaCorreoBussnies>();
builder.Services.AddScoped<IPersonaDireccionBussnies, PersonaDireccionBussnies>();
builder.Services.AddScoped<IPersonaEmpleoBussnies, PersonaEmpleoBussnies>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
