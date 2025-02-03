using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors(); //llamamos los metodos que creamos en la clase static
builder.Services.ConfigureIISIntegration(); //llamamos los metodos que creamos en la clase static

builder.Services.AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage(); //nos muestra los errores
else 
    app.UseHsts(); //seguridad cuando es en produccion 

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
