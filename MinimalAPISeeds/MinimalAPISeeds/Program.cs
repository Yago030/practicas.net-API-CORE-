using Microsoft.EntityFrameworkCore;
using MinimalAPISeeds;
using MinimalAPISeeds.Endpoints;
using MinimalAPISeeds.Inicializador;
using MinimalAPISeeds.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Configuración de los servicios
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

    // Descomentar para producción
    //options.AddDefaultPolicy(policy =>
    //{
    //    policy.WithOrigins("https://tu-frontend.com")
    //          .AllowAnyHeader()
    //          .AllowAnyMethod();
    //});
});

builder.Services.AddOutputCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de repositorios
builder.Services.AddScoped<IRepositorioCrop, RepositorioCrops>();
builder.Services.AddScoped<IRepositorioSeasons, RepositorioSeasons>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IRepositorioPlantingMethods, RepositorioPlantingMethods>();
builder.Services.AddScoped<IDbInicializador, DbInicializador>();

// Construcción de la aplicación
var app = builder.Build();

// Aplicar Migraciones y Datos Iniciales
using (var scope = app.Services.CreateScope())
{
    var dbInicializador = scope.ServiceProvider.GetRequiredService<IDbInicializador>();
    dbInicializador.Inicializar();
}

// Configuración del middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseCors();
app.UseOutputCache();
app.UseHttpsRedirection();

app.MapGet("/", () => "¡API Funcionando!");

app.MapGroup("/crops").MapCrops();
app.MapGroup("/seasons").MapSeasons();
app.MapGroup("/planting-methods").MapPlantingMethods();

app.Run();
