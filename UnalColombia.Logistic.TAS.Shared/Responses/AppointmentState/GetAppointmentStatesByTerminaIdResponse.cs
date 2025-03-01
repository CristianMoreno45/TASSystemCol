using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnalColombia.Logistic.TAS.Shared.Responses.AppointmentState
{
    public class GetAppointmentStatesByTerminaIdResponse
    {
        public List<Domain.Entities.AppointmentState> AppointmentStates { get; set; }
    }
}
