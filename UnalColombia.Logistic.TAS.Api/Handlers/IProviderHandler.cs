using UnalColombia.Logistic.TAS.Shared.Requests.Provider;
using UnalColombia.Logistic.TAS.Shared.Responses.Provider;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface IProviderHandler
    {
        GetProvidersWithUserInformationResponse GetProvidersWithUserInformation(GetProvidersWithUserInformationRequest request);
    }
}