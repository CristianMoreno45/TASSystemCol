using UnalColombia.Logistic.TAS.Domain.Entities;

namespace UnalColombia.Logistic.TAS.Shared.Responses.Appointment
{
    public class GetAppointmentsByUserIdResponse
    {
        public List<GetAppointmentsByUserIdElementResponse> Appointments { get; set; }
    }

    public class GetAppointmentsByUserIdElementResponse
    {
        public Guid AppointmentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public Guid CalendarId { get; set; }
        public int TerminalId { get; set; }
        public string TerminalName { get; set; }
        public string CalendarName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string FisicalLocation { get; set; }
        public bool IsActive { get; set; }
        public List<MissionAppointmet>? Missions { get; set; }
    }
}
