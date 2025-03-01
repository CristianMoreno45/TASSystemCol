using UnalColombia.Logistic.TAS.Shared.Requests.City;
using UnalColombia.Logistic.TAS.Shared.Responses.City;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface ICityHandler
    {
        GetCitiesByStateIdResponse GetCitiesByStateId(GetCitiesByStateIdRequest request);
    }
}