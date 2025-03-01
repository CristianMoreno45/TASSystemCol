using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Shared.Requests.Driver;
using UnalColombia.Logistic.TAS.Shared.Responses.Driver;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class DriverHandler : IDriverHandler
    {
        private readonly ILogger _logger;
        private readonly IDriverRepository _driverRepository;

        public DriverHandler(ILogger logger, IDriverRepository driverRepository)
        {
            _logger = logger;
            _driverRepository = driverRepository;
        }

        public GetDriverByUserIdResponse GetDriverByUserId(GetDriverByUserIdRequest request)
        {
            var driver = _driverRepository
                .GetByFilter(x =>
                    x.UserId == request.UserId
                    && x.IsActive).FirstOrDefault();
            if (driver == null) driver = new Domain.Entities.Driver();
            return new GetDriverByUserIdResponse() { DriverInfo = driver };
        }
    }

}
