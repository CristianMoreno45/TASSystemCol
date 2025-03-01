using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class LocationRepository : BaseRepository<Domain.Entities.Location, TASDbContext>, ILocationRepository
    {
        public LocationRepository(TASDbContext context) : base(context)
        {
        }
    }
}
