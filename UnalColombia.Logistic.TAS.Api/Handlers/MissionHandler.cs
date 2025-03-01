using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Shared.Requests.City;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class MissionHandler: IMissionHandler
    {
        private readonly IMissionRepository _missionRepository;

        public MissionHandler(IMissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }

        public List<Mission>? GetMissionesByTerminalId(int missionId)
        {
            return _missionRepository.GetMissionesByTerminalId(missionId).ToList();
        }
    }
}