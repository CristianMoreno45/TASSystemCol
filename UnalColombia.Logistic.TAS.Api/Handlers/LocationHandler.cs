using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Shared.Requests.Location;
using UnalColombia.Logistic.TAS.Shared.Responses.Location;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class LocationHandler : ILocationHandler
    {
        private readonly ILogger _logger;
        private readonly ILocationRepository _locationRepository;

        public LocationHandler(ILogger logger, ILocationRepository locationRepository)
        {
            _logger = logger;
            _locationRepository = locationRepository;
        }

        public GetLocationsByTerminalIdResponse GetLocationsByTerminalId(GetLocationsByTerminalIdRequest request)
        {
            var locations = _locationRepository
                .GetByFilter(x =>
                    x.TerminalId == request.TerminalId
                    && x.IsActive).ToList();
            return new GetLocationsByTerminalIdResponse() { Locations = locations };
        }
    }

}
