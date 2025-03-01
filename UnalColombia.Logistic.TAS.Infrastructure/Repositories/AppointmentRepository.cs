using System.Globalization;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class AppointmentRepository : BaseRepository<Domain.Entities.Appointment, TASDbContext>, IAppointmentRepository
    {
        public AppointmentRepository(TASDbContext context) : base(context)
        {
        }

        public Domain.Entities.Appointment? GetAllInformationById(Guid id)
        {
            return _model
                .Where(x => x.AppointmentId == id)
                .Include(x => x.Location)
                .Include(x => x.CreatedByUser)
                .Include(x => x.AppointmentState)
                .Include(x => x.Calendar)
                    .ThenInclude(x => x.Terminal)
                .Include(x => x.Driver)
                    .ThenInclude(x => x.User)
                .Include(x => x.Provider)
                    .ThenInclude(x => x.User)
                .Include(x => x.CargoInformation)
                    .ThenInclude(x => x.GeographicalLocationOrigin)
                .Include(x => x.CargoInformation)
                    .ThenInclude(x => x.GeographicalLocationDestination)
                .Include(x => x.CargoInformation)
                    .ThenInclude(x => x.TypeContainer)
                .FirstOrDefault();

        }

        public List<Domain.Entities.Appointment>? GetAppointmentListDynamicFilter(Expression<Func<Domain.Entities.Appointment, bool>> filter)
        {
            return _model
                    .Where(filter)
                    .Where(app => !app.AppointmentState.IsReserve && app.AppointmentState.IsActive)
                    .Select(app => new Appointment
                    {
                        AppointmentId = app.AppointmentId,
                        StartTime = app.StartTime,
                        FinishTime = app.FinishTime,
                        Calendar = new Domain.Entities.Calendar
                        {
                            CalendarId = app.Calendar.CalendarId,
                            Name = app.Calendar.Name,
                            Terminal = new Terminal
                            {
                                TerminalId = app.Calendar.Terminal.TerminalId,
                                Name = app.Calendar.Terminal.Name
                            }
                        },
                        Location = new Location
                        {
                            LocationId = app.Location.LocationId,
                            Name = app.Location.Name,
                            FisicalLocation = app.Location.FisicalLocation
                        },
                        Driver = new Driver
                        {
                            DriverId = app.Driver.DriverId,
                            UserId = app.Driver.UserId,
                            Phone = app.Driver.Phone,
                            IdentificationNumber = app.Driver.IdentificationNumber,
                            User = new User
                            {
                                UserId = app.Driver.User.UserId,
                                Name = app.Driver.User.Name,
                                UserName = app.Driver.User.UserName
                            }
                        },
                        MissionAppointmets = app.MissionAppointmets
                            .Select(ma => new MissionAppointmet
                            {
                                MissionId = ma.MissionId,
                                AppointmentId = app.AppointmentId,
                                Mission =  new Mission
                                {
                                    MissionId = ma.MissionId,
                                    Description = ma.Mission.Description,
                                    Points = ma.Mission.Points,
                                },
                                IsAchieved = ma.IsAchieved
                            }).ToList()
                    })
                    .OrderBy(app => app.StartTime)
                    .AsNoTracking() // Para evitar tracking innecesario
                    .ToList();


        }
    }
}
