using NLog;
using MyAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Contracts;
using Repository.Repositories;
using Presentation;


var builder = WebApplication.CreateBuilder(args);

// Configurar NLog cargando el archivo nlog.config
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("sqlConnection");

// Registrar el servicio del logger
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.ConfigureLoggerService();

// Configurar el contexto de la base de datos
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
// Agregar servicios al contenedor
builder.Services.AddControllers();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
