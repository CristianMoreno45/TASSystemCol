using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Shared.Requests.AppointmentState;
using UnalColombia.Logistic.TAS.Shared.Responses.AppointmentState;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface IAppointmentStateHandler
    {
        GetAppointmentStatesByTerminaIdResponse GetAppointmentStatesByTerminaId(GetAppointmentStatesByTerminaIdRequest request);
        AppointmentState? GetAppointmentReserveStateByTerminaId(int terminalId);
        AppointmentState? GetAppointmentApprovedStateByTerminaId(int terminalId);
    }
}