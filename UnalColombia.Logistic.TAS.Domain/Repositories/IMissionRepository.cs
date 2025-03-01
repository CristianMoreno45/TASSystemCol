using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Entities;

namespace UnalColombia.Logistic.TAS.Domain.Repositories
{
    public interface IMissionRepository : IRepositoryAsync<Entities.Mission>
    {
        IEnumerable<Mission>? GetMissionesByTerminalId(int terminalId);
    }
}
