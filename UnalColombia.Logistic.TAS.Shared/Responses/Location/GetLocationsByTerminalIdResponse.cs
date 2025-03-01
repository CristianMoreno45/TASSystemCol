using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnalColombia.Logistic.TAS.Shared.Responses.Location
{
    public class GetLocationsByTerminalIdResponse
    {
        public List<Domain.Entities.Location> Locations { get; set; }
    }
}
