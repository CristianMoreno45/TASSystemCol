using UnalColombia.Common.API;
using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Api.Controllers
{
    public static class APIExtension
    {

        public static void CreateCRUDEnpoint(WebApplication app)
        {
            app.MapCrudEndpoints<Appointment, TASDbContext>("appointment");
            app.MapCrudEndpoints<AppointmentState, TASDbContext>("appointmentstate");
            app.MapCrudEndpoints<Calendar, TASDbContext>("calendar");
            app.MapCrudEndpoints<CargoInformation, TASDbContext>("cargoinformation");
            app.MapCrudEndpoints<Category, TASDbContext>("category");
            app.MapCrudEndpoints<City, TASDbContext>("city");
            app.MapCrudEndpoints<DayOfWeekSettings, TASDbContext>("dayofweeksettings");
            app.MapCrudEndpoints<DeadBand, TASDbContext>("deadband");
            app.MapCrudEndpoints<Driver, TASDbContext>("driver");
            app.MapCrudEndpoints<HistoryAppointment, TASDbContext>("historyappointment");
            app.MapCrudEndpoints<HistoryPoint, TASDbContext>("historypoint");
            app.MapCrudEndpoints<IdentificationType, TASDbContext>("identificationtype");
            app.MapCrudEndpoints<ISOCountry, TASDbContext>("isocountry");
            app.MapCrudEndpoints<Location, TASDbContext>("location");
            app.MapCrudEndpoints<Mission, TASDbContext>("mission");
            app.MapCrudEndpoints<MissionAppointmet, TASDbContext>("missionappointmet");
            app.MapCrudEndpoints<Operator, TASDbContext>("operator");
            app.MapCrudEndpoints<Provider, TASDbContext>("provider");
            app.MapCrudEndpoints<State, TASDbContext>("state");
            app.MapCrudEndpoints<SuperPower, TASDbContext>("superpower");
            app.MapCrudEndpoints<SuperPowerUser, TASDbContext>("superpoweruser");
            app.MapCrudEndpoints<Terminal, TASDbContext>("terminal");
            app.MapCrudEndpoints<TerminalOperator, TASDbContext>("terminaloperator");
            app.MapCrudEndpoints<TypeContainer, TASDbContext>("typecontainer");
            app.MapCrudEndpoints<User, TASDbContext>("user");
            app.MapCrudEndpoints<Wallet, TASDbContext>("wallet");
        }
    }
}
