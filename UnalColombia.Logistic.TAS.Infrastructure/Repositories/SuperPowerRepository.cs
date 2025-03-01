using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class SuperPowerRepository : BaseRepository<Domain.Entities.SuperPower, TASDbContext>, ISuperPowerRepository
    {
        public SuperPowerRepository(TASDbContext context) : base(context)
        {

        }
    }
}
