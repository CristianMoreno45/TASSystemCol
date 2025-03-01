using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Domain.Repositories;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class SuperPowerHandler : ISuperPowerHandler
    {
        private readonly ILogger _logger;
        private readonly ISuperPowerRepository _superPowerRepository;

        public SuperPowerHandler(ILogger logger, ISuperPowerRepository superPowerRepository)
        {
            _logger = logger;
            _superPowerRepository = superPowerRepository;
        }


        public async Task<SuperPower> GetSuperPowerById(Guid superPowerId)
        {
            var superPower = await _superPowerRepository.GetByIdAsync(superPowerId);
            return superPower;
        }

    }


}
