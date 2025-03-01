using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Shared.Requests.AppointmentState;
using UnalColombia.Logistic.TAS.Shared.Responses.AppointmentState;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class AppointmentStateHandler : IAppointmentStateHandler
    {
        private readonly ILogger _logger;
        private readonly IAppointmentStateRepository _appointmentStateRepository;

        public AppointmentStateHandler(ILogger logger, IAppointmentStateRepository appointmentStateRepository)
        {
            _logger = logger;
            _appointmentStateRepository = appointmentStateRepository;
        }

        public GetAppointmentStatesByTerminaIdResponse GetAppointmentStatesByTerminaId(GetAppointmentStatesByTerminaIdRequest request)
        {
            var appointmentStates = _appointmentStateRepository
                .GetByFilter(x =>
                    x.TerminalId == request.TerminalId
                    && x.IsActive).ToList();

            return new GetAppointmentStatesByTerminaIdResponse() { AppointmentStates = appointmentStates };
        }
        public AppointmentState? GetAppointmentReserveStateByTerminaId(int terminalId)
        {
            var appointmentStates = _appointmentStateRepository
                .GetByFilter(x =>
                    x.TerminalId == terminalId
                    && x.IsReserve
                    && x.IsActive).FirstOrDefault();

            return appointmentStates;
        }
        public AppointmentState? GetAppointmentApprovedStateByTerminaId(int terminalId)
        {
            var appointmentStates = _appointmentStateRepository
                .GetByFilter(x =>
                    x.TerminalId == terminalId
                    && !x.IsReserve
                    && x.IsActive).FirstOrDefault();

            return appointmentStates;
        }
    }
}
