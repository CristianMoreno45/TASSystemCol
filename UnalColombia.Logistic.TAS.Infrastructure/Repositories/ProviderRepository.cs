using Microsoft.EntityFrameworkCore;
using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class ProviderRepository : BaseRepository<Domain.Entities.Provider, TASDbContext>, IProviderRepository
    {
        public ProviderRepository(TASDbContext context) : base(context)
        { 
        }
        public IEnumerable<Domain.Entities.Provider> GetProvidersWithUserInformation()
        {
            return [.. _model.Where(x=> x.IsActive == true).Include(x => x.User)];
        }
    }
}
