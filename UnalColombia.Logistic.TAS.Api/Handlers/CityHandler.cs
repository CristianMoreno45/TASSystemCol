using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Shared.Requests.City;
using UnalColombia.Logistic.TAS.Shared.Responses.City;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class CityHandler : ICityHandler
    {
        private readonly ILogger _logger;
        private readonly ICityRepository _cityRepository;

        public CityHandler(ILogger logger, ICityRepository cityRepository)
        {
            _logger = logger;
            _cityRepository = cityRepository;
        }

        public GetCitiesByStateIdResponse GetCitiesByStateId(GetCitiesByStateIdRequest request)
        {
            var cities = _cityRepository
                .GetByFilter(x =>
                    x.StateId == request.StateId
                    && x.IsActive).ToList();
            return new GetCitiesByStateIdResponse() { Cities = cities };
        }
    }
}
