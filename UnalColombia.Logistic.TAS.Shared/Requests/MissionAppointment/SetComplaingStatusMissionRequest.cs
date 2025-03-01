using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnalColombia.Logistic.TAS.Shared.Requests.MissionAppointment
{
    public class SetComplaingStatusMissionRequest
    {
        public List<SetComplaingStatusMissionItemRequest> Missions { get; set; }
    }

    public class SetComplaingStatusMissionItemRequest
    {
        public Guid AppointmentId { get; set; }
        public int MissionId { get; set; }
        public bool IsAchieved { get; set; }

    }
}
