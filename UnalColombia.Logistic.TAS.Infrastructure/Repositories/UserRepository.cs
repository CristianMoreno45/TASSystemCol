using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<Domain.Entities.User, TASDbContext>, IUserRepository
    {
        public UserRepository(TASDbContext context) : base(context)
        {
        }
    }
}
