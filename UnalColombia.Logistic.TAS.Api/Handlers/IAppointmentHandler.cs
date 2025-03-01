using UnalColombia.Logistic.TAS.Shared.Requests.Appointment;
using UnalColombia.Logistic.TAS.Shared.Responses.Appointment;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface IAppointmentHandler
    {
        Task<Guid> ReserveAppointment(ReserveAppointmentRequest request);
        GetAllInformationByIdResponse GetAllInformationById(GetAllInformationByIdRequest request);
        Task<GetSummaryAppointmentListResponse> GetSummaryAppointmentList(GetSummaryAppointmentListRequest request);
        Task<GetAppointmentsByUserIdResponse> GetAppointmentsByUserId(GetAppointmentsByUserIdRequest request);
        Task<bool> SetComplaingStatusMission(Guid appointmentId);
    }
}