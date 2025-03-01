using UnalColombia.Logistic.TAS.Shared.Requests.City;
using UnalColombia.Logistic.TAS.Shared.Requests.MissionAppointment;
using UnalColombia.Logistic.TAS.Shared.Responses.City;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface IMissionAppointmentHandler
    {
        Task<bool> SetComplaingStatusMission(SetComplaingStatusMissionRequest request);
    }
}