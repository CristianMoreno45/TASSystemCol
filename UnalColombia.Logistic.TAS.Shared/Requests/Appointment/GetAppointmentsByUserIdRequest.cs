using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnalColombia.Logistic.TAS.Shared.Requests.Appointment
{
    public class GetAppointmentsByUserIdRequest
    {
        public Guid UserId { get; set; }
        public int TypeOfAppointments { get; set; }
    }
}
