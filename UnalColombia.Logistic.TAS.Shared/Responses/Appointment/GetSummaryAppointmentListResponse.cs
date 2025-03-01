using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnalColombia.Logistic.TAS.Shared.Responses.Appointment
{
    public class GetSummaryAppointmentListResponse
    {
        public List<GetSummaryAppointmentElementResponse> Appointments { get; set; }
    }
    public class GetSummaryAppointmentElementResponse
    {
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public Guid CalendarId { get; set; }
        public string CalendarName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string FisicalLocation { get; set; }
    }
}
