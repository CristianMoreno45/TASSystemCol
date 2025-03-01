using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Shared.Requests.Provider;
using UnalColombia.Logistic.TAS.Shared.Responses.Provider;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class ProviderHandler : IProviderHandler
    {
        private readonly ILogger _logger;
        private readonly IProviderRepository _providerRepository;

        public ProviderHandler(ILogger logger, IProviderRepository providerRepository)
        {
            _logger = logger;
            _providerRepository = providerRepository;
        }

        public GetProvidersWithUserInformationResponse GetProvidersWithUserInformation(GetProvidersWithUserInformationRequest request)
        {
            var appointmentState = _providerRepository.GetProvidersWithUserInformation().ToList();

            return new GetProvidersWithUserInformationResponse() { Providers = appointmentState };
        }
    }

}
