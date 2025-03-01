using System.Linq.Expressions;
using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Shared.Requests.Appointment;
using UnalColombia.Logistic.TAS.Shared.Responses.Appointment;
using UnalColombia.Common.Extensions.Lambda;
using UnalColombia.Common.Extensions.DateTimeExtensions;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class AppointmentHandler : IAppointmentHandler
    {
        private readonly ILogger _logger;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAppointmentStateHandler _appointmentStateService;
        private readonly IMissionHandler _missionHandler;

        public AppointmentHandler(ILogger logger,
            IAppointmentRepository appointmentRepository,
            IAppointmentStateHandler appointmentStateService,
            IMissionHandler missionHandler)
        {
            _logger = logger;
            _appointmentRepository = appointmentRepository;
            _appointmentStateService = appointmentStateService;
            _missionHandler = missionHandler;
        }

        public GetAllInformationByIdResponse GetAllInformationById(GetAllInformationByIdRequest request)
        {
            var result = _appointmentRepository.GetAllInformationById(request.AppointmentId);
            if (result == null) return new GetAllInformationByIdResponse();
            var response = new GetAllInformationByIdResponse()
            {
                AppointmentId = result.AppointmentId,
                AppointmentState = result.AppointmentState.Name,
                Terminal = result.Calendar.Terminal.Name,
                Location = $"{result.Location.Name} - {result.Location.FisicalLocation}",
                DriverName = result.Driver.User.Name,
                DriverPhone = result.Driver.Phone,
                UserEmail = result.Driver.User.UserName,
                ProviderName = result.Provider.User.Name,
                ProviderPhone = result.Provider.ContactPhone,
                CalendaName = result.Calendar.Name,
                Description = result.Description,
                StartTime = result.StartTime,
                FinishTime = result.FinishTime,
                createdDate = result.CreatedDate,
                createdUserId = result.CreatedUserId,
                cargoInformationId = result.CargoInformation.First().CargoInformationId,
                ContainerId = result.CargoInformation.First().ContainerId,
                LengthInFeet = result.CargoInformation.First().LengthInFeet,
                HeightInFeet = result.CargoInformation.First().HeightInFeet,
                WidthInFeet = result.CargoInformation.First().WidthInFeet,
                GrossWeightInKilos = result.CargoInformation.First().GrossWeightInKilos,
                NetWeightInKilos = result.CargoInformation.First().NetWeightInKilos,
                TypeContainer = $"{result.CargoInformation.First().TypeContainer.Code} - {result.CargoInformation.First().TypeContainer.Description}",
                GeographicalLocationOriginISOCountry = $"{result.CargoInformation.First().GeographicalLocationOrigin.A2} - {result.CargoInformation.First().GeographicalLocationOrigin.Name}",
                GeographicalLocationDestinationISOCountry = $"{result.CargoInformation.First().GeographicalLocationOrigin.A2} - {result.CargoInformation.First().GeographicalLocationDestination.Name}",
                IsLoaded = result.CargoInformation.First().IsLoaded,
                TractorTrailerRegistrationNumber = result.CargoInformation.First().TractorTrailerRegistrationNumber,
                IsOversizedLoad = result.CargoInformation.First().IsOversizedLoad,
                IMOCode = result.CargoInformation.First().IMOCode,
                RequiredCelciusTemperature = result.CargoInformation.First().RequiredCelciusTemperature,
                Notes = result.CargoInformation.First().Notes,
                IsActive = result.IsActive
            };
            return response;
        }

        public async Task<Guid> ReserveAppointment(ReserveAppointmentRequest request)
        {

            int appointmentStateId = _appointmentStateService.GetAppointmentApprovedStateByTerminaId(request.TerminalId)?.AppointmentStateId ?? 1;
            var missions = _missionHandler.GetMissionesByTerminalId(request.TerminalId);
            List<MissionAppointmet> missionByAppointnment = new List<MissionAppointmet>();

            missions.ForEach(e =>
            {
                missionByAppointnment.Add(new MissionAppointmet() { MissionId = e.MissionId, IsAchieved = false });
            });


            var appointment = new Appointment()
            {
                AppointmentId = Guid.NewGuid(),
                AppointmentStateId = appointmentStateId,
                LocationId = request.LocationId,
                ProviderId = request.ProviderId,
                DriverId = request.DriverId,
                CalendarId = request.CalendarId,
                Description = request.Description,
                Title = $"{request.DriverId}:{request.TerminalId}",
                StartTime = request.StartTime,
                FinishTime = request.FinishTime,
                CreatedUserId = request.UserId,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                CargoInformation =
                [
                    new CargoInformation()
                    {
                        ContainerId = request.ContainerId,
                        LengthInFeet = request.LengthInFeet,
                        HeightInFeet = request.HeightInFeet,
                        WidthInFeet = request.WidthInFeet,
                        GrossWeightInKilos = request.GrossWeightInKilos,
                        NetWeightInKilos = request.NetWeightInKilos,
                        TypeContainerId = request.TypeContainerId,
                        GeographicalLocationOriginISOCountryId = request.GeographicalLocationOriginISOCountryId,
                        GeographicalLocationDestinationISOCountryId = request.GeographicalLocationDestinationISOCountryId,
                        IsLoaded = request.IsLoaded,
                        TypeCargo = "",
                        TractorTrailerRegistrationNumber = request.TractorTrailerRegistrationNumber,
                        IsOversizedLoad = request.IsOversizedLoad,
                        IMOCode = request.IMOCode,
                        RequiredCelciusTemperature = request.RequiredCelciusTemperature??0,
                        Notes = request.Notes,
                        IsActive = true
                    }

                ],
                MissionAppointmets = missionByAppointnment
            };
            await _appointmentRepository.Add(appointment);


            return appointment.AppointmentId;
        }

        public async Task<GetSummaryAppointmentListResponse> GetSummaryAppointmentList(GetSummaryAppointmentListRequest request)
        {
            var response = new GetSummaryAppointmentListResponse()
            {
                Appointments = new List<GetSummaryAppointmentElementResponse>()
            };

            var fdFilter = request.FinishDate == null ? request.StartDate.Add(new TimeSpan(1, 0, 0, 0)) : ((DateTime)request.FinishDate).AddHours(24);

            Expression<Func<Domain.Entities.Appointment, bool>> filter = x => x.FinishTime <= fdFilter;
            filter = filter.CombineWith(x => x.StartTime >= request.StartDate, ExpressionType.AndAlso);
            filter = filter.CombineWith(x => x.CalendarId == request.CalendarId, ExpressionType.AndAlso);
            var appointments = _appointmentRepository.GetAppointmentListDynamicFilter(filter);
            if (appointments == null) return response;
            foreach (var item in appointments)
            {
                response.Appointments.Add(
                    new GetSummaryAppointmentElementResponse()
                    {
                        StartTime = item.StartTime,
                        FinishTime = item.FinishTime,
                        CalendarId = item.CalendarId,
                        CalendarName = item.Calendar.Name,
                        LocationId = item.LocationId,
                        LocationName = item.Location.Name,
                        FisicalLocation = item.Location.FisicalLocation
                    });
            }

            return response;
        }

        public async Task<GetAppointmentsByUserIdResponse> GetAppointmentsByUserId(GetAppointmentsByUserIdRequest request)
        {
            var response = new GetAppointmentsByUserIdResponse()
            {
                Appointments = new List<GetAppointmentsByUserIdElementResponse>()
            };
            var today = DateTime.UtcNow;
            Expression<Func<Domain.Entities.Appointment, bool>> filter = x => x.IsActive == true;
            filter = filter.CombineWith(x => x.Driver.User.UserId >= request.UserId, ExpressionType.AndAlso);
            switch (request.TypeOfAppointments)
            {
                case 1: // rango
                    filter = filter.CombineWith(x => x.StartTime > today.AddDays(-1) && x.StartTime < today.AddDays(1), ExpressionType.AndAlso);
                    filter = filter.CombineWith(x => x.Driver.User.UserId >= request.UserId && x.AppointmentStateId < 3, ExpressionType.AndAlso);

                    break;
                case 2: // canceladas
                    filter = x => x.IsActive == false;
                    filter = filter.CombineWith(x => x.Driver.User.UserId >= request.UserId, ExpressionType.AndAlso);
                    break;
                case 3: // futuras
                    filter = filter.CombineWith(x => x.StartTime >= today && x.AppointmentStateId < 3, ExpressionType.AndAlso);
                    break;
                case 5: // Cumplidas
                    //TODO: agregar campo en AppointmentState para saber cuando una cita es cumplida (isAchieved)
                    filter = filter.CombineWith(x => x.AppointmentStateId == 3, ExpressionType.AndAlso);
                    break;
                case 4: // Operario
                        //TODO: agregar campo en AppointmentState para saber cuando una cita es cumplida (isAchieved)
                        //TODO: Ajustar traer las citas por la terminal del usuario operador
                        //      en lugar de las citas que fueron asociadas con misisones del usuario operador
                    filter = x => x.AppointmentStateId < 3
                    && x.IsActive == true
                    && x.MissionAppointmets.First().Mission.CreatedUserId == request.UserId;

                    break;
            }


            var appointments = _appointmentRepository.GetAppointmentListDynamicFilter(filter);
            if (appointments == null) return response;

            foreach (var item in appointments)
            {
                response.Appointments.Add(
                    new GetAppointmentsByUserIdElementResponse()
                    {
                        AppointmentId = item.AppointmentId,
                        StartTime = item.StartTime,
                        FinishTime = item.FinishTime,
                        TerminalId = item.Calendar.TerminalId,
                        TerminalName = item.Calendar.Terminal.Name,
                        CalendarId = item.CalendarId,
                        CalendarName = item.Calendar.Name,
                        LocationId = item.LocationId,
                        LocationName = item.Location.Name,
                        FisicalLocation = item.Location.FisicalLocation ?? "",
                        IsActive = item.IsActive,
                        Missions = item.MissionAppointmets.ToList()
                    });
            }

            return response;
        }

        public async Task<bool> SetComplaingStatusMission(Guid appointmentId)
        {
            var appointment = _appointmentRepository.GetAllInformationById(appointmentId);
            if (appointment == null) return false;


            if (appointment.HistoryAppointments == null)
                appointment.HistoryAppointments = new List<HistoryAppointment>();
            appointment.HistoryAppointments.Add(new HistoryAppointment()
            {
                AppointmentId = appointmentId,
                AppointmentStateId = appointment.AppointmentStateId,
                ProviderId = appointment.ProviderId,
                LocationId = appointment.LocationId,
                DriverId = appointment.DriverId,
                CalendarId = appointment.CalendarId,
                Title = appointment.Title,
                Description = appointment.Description,
                StartTime = new TimeSpan(1,1,1),
                FinishTime = new TimeSpan(1, 1, 1),
                CreatedUserId = appointment.CreatedUserId,
                CreatedDate = appointment.CreatedDate,
                LastUpdatedUserId = appointment.LastUpdatedUserId,
                LastUpdatedDate = DateTime.Now,
                IsActive = appointment.IsActive
            });

            appointment.AppointmentStateId = 3;
            await _appointmentRepository.Update(appointment);

            await _appointmentRepository.SaveChangesAsync();
            return true;
        }


    }


}
