using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class TerminalOperatorRepository : BaseRepository<Domain.Entities.TerminalOperator, TASDbContext>, ITerminalOperatorRepository
    {
        public TerminalOperatorRepository(TASDbContext context) : base(context)
        {
        }
    }
}
