using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class DriverRepository : BaseRepository<Domain.Entities.Driver, TASDbContext>, IDriverRepository
    {
        public DriverRepository(TASDbContext context) : base(context)
        {
        }
    }
}
