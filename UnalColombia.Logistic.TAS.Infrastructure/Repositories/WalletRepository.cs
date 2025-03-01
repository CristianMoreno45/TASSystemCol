using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class WalletRepository : BaseRepository<Domain.Entities.Wallet, TASDbContext>, IWalletRepository
    {
        public WalletRepository(TASDbContext context) : base(context)
        {

        }
    }
}
