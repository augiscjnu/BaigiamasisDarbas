using KnyguNuoma.Core.Contracts;
using KnyguNuoma.Core.ServicesContracts;
using KnyguNuoma.Infrastructure.Repozitorijos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var log = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/logginSample.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Logger = log;
builder.Services.AddSingleton(Log.Logger);  // Registering logger in DI


// Knygø repo
builder.Services.AddTransient<IKnyguRepozitorija>(x => new KnyguRepozitorija("Server=localhost;Database=BaigiamasisDarbas;Trusted_Connection=True;TrustServerCertificate=true;"));
builder.Services.AddTransient<INuomosRepozitorija>(x => new NuomosRepozitorija("Server=localhost;Database=BaigiamasisDarbas;Trusted_Connection=True;TrustServerCertificate=true;"));
builder.Services.AddTransient<INaudotojøRepozitorija>(x => new NaudotojøRepozitorija("Server=localhost;Database=BaigiamasisDarbas;Trusted_Connection=True;TrustServerCertificate=true;"));



// Klientai repo (Jei reikia, pridedame)

// Nuomos uþsakymai repo (Jei reikia, pridedame)

// MVC / API paslaugos
builder.Services.AddControllers();

// Swagger/OpenAPI konfigûracija
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Konfigûruojame HTTP uþklausø apdorojimo sekà
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // Marðrutø registracija

app.Run();
