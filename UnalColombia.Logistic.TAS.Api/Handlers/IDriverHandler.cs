using UnalColombia.Logistic.TAS.Shared.Requests.Driver;
using UnalColombia.Logistic.TAS.Shared.Responses.Driver;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface IDriverHandler
    {
        GetDriverByUserIdResponse GetDriverByUserId(GetDriverByUserIdRequest request);
    }
}