using UnalColombia.Logistic.TAS.Shared.Requests.Location;
using UnalColombia.Logistic.TAS.Shared.Responses.Location;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface ILocationHandler
    {
        GetLocationsByTerminalIdResponse GetLocationsByTerminalId(GetLocationsByTerminalIdRequest request);
    }
}