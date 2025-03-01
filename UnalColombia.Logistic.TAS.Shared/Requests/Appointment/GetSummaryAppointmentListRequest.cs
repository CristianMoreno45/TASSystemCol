using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnalColombia.Logistic.TAS.Shared.Requests.Appointment
{
    public class GetSummaryAppointmentListRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public Guid CalendarId { get; set; }
        public int LocationId { get; set; }
    }
}
