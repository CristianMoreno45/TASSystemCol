using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Shared.Requests.City;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface IMissionHandler
    {
        List<Mission> GetMissionesByTerminalId(int missionId);
    }
}