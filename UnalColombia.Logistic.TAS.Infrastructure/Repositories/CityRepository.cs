using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class CityRepository : BaseRepository<Domain.Entities.City, TASDbContext>, ICityRepository
    {
        public CityRepository(TASDbContext context) : base(context)
        {
        }
    }
}
