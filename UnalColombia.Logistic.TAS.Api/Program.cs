using FluentValidation;
using UnalColombia.Logistic.TAS.Domain.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using UnalColombia.Common.Extensions.Program;
using UnalColombia.Common.Extensions.Dto;
using UnalColombia.Logistic.TAS.Api.Controllers;
using UnalColombia.Logistic.TAS.Api.Handlers;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Repositories;


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

// Agregar servicios para controladores
builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICalendarRepository, CalendarRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IAppointmentStateRepository, AppointmentStateRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IMissionRepository, MissionRepository>();
builder.Services.AddScoped<ITerminalOperatorRepository, TerminalOperatorRepository>();
builder.Services.AddScoped<IMissionAppointmentRepository, MissionAppointmentRepository>();
builder.Services.AddScoped<IWalletUserRepository, WalletUserRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<ISuperPowerRepository, SuperPowerRepository>();


builder.Services.AddScoped<ICalendarHandler, CalendarHandler>();
builder.Services.AddScoped<IUserHandler, UserHandler>();
builder.Services.AddScoped<IDriverHandler, DriverHandler>();
builder.Services.AddScoped<IAppointmentStateHandler, AppointmentStateHandler>();
builder.Services.AddScoped<IProviderHandler, ProviderHandler>();
builder.Services.AddScoped<ICityHandler, CityHandler>();
builder.Services.AddScoped<IAppointmentHandler, AppointmentHandler>();
builder.Services.AddScoped<ILocationHandler, LocationHandler>();
builder.Services.AddScoped<IMissionHandler, MissionHandler>();
builder.Services.AddScoped<ITerminalOperatorHandler, TerminalOperatorHandler>();
builder.Services.AddScoped<IMissionAppointmentHandler, MissionAppointmentHandler>();
builder.Services.AddScoped<IWalletUserHandler, WalletUserHandler>();
builder.Services.AddScoped<ISuperPowerHandler, SuperPowerHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

services.ConfigureJsonPreferences()
    .AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    ); // Add Json configuration


var app = builder.Build();

// Mapear los controladores tradicionales
app.MapControllers();

// Definir endpoints con Minimal API
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

app.UseHttpsRedirection().UseCors("MyPolicy");//.UseAuthentication().UseAuthorization(); 

app.Run();

