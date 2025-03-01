using Microsoft.EntityFrameworkCore;
using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class MissionRepository : BaseRepository<Domain.Entities.Mission, TASDbContext>, IMissionRepository
    {
        public MissionRepository(TASDbContext context) : base(context)
        {
        }

        public IEnumerable<Mission>? GetMissionesByTerminalId(int terminalId)
        {

            return _model
                .Where(x => x.IsActive == true)
                .Include(x => x.CreatedByUser)
                     .ThenInclude(x => x.Terminal)
                .Where(x => x.CreatedByUser.TerminalId == terminalId);
              
        }
    }
}
