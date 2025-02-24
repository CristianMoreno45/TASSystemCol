using Microsoft.AspNetCore.Identity;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using UnalColombia.Logistic.TAS.Domain.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using UnalColombia.Common.Extensions.Program;
using UnalColombia.Common.Extensions.Dto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Common.API;
using System.Collections.Generic;
using UnalColombia.Logistic.TAS.Api.Controllers;


var builder = WebApplication.CreateBuilder(args);


// Registrar todos los validadores de un ensamblado específico
builder.Services.AddValidatorsFromAssembly(typeof(AppointmentValidator).Assembly);
// Configuration of Appsettings.json
builder.Host.SetAppSettings(builder.Environment.EnvironmentName);
// Add Cors fisical Policy
builder.Services.SetPhysicalPolicy("MyPolicy");
// Add Logger
using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddSimpleConsole(i => i.ColorBehavior = LoggerColorBehavior.Disabled);
});
ILogger logger = loggerFactory.CreateLogger<Program>();
builder.Services.AddSingleton(logger);

IConfiguration configuration = builder.Configuration;
IServiceCollection services = builder.Services;

// Add db Context
services.AddDbContext<TASDbContext>(opt =>
{
    opt.UseSqlServer(configuration["StringConnections:tasdb"],
        x => x.MigrationsAssembly("UnalColombia.Logistic.TAS.Infrastructure"));
});

//builder.Services.AddScoped<IUserRepository, UserRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

APIExtension.CreateCRUDEnpoint(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Start migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TASDbContext>();
    db.Database.Migrate();
}

// Add Expetion handler in preprocesor request
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = Text.Plain;

        await context.Response.WriteAsJsonAsync(
            Results.Json(
                false.AsResponseDTO(HttpStatusCode.InternalServerError,
                "No se pudo resolver la operación, por favor intente nuevamente más tarde."),
                statusCode: (int)HttpStatusCode.InternalServerError));
    });
});

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();

