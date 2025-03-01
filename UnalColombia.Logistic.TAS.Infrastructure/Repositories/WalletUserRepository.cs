using Microsoft.EntityFrameworkCore;
using UnalColombia.Common.Infrastructure;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Persistence;

namespace UnalColombia.Logistic.TAS.Infrastructure.Repositories
{
    public class WalletUserRepository : BaseRepository<Domain.Entities.WalletUser, TASDbContext>, IWalletUserRepository
    {
        public WalletUserRepository(TASDbContext context) : base(context)
        {

        }

        public IEnumerable<Domain.Entities.WalletUser> GetWalletsByUser(Guid userId)
        {
            return [.. _model.Where(x => x.UserId == userId)
                .Include(x => x.Wallet)
                .Include(x => x.HistoryPoints)];
        }
        public Domain.Entities.WalletUser? GetWalletsByUserAndWalled(Guid userId, Guid walletId)
        {
            return _model.Where(x => x.UserId == userId && x.WalletId == walletId)
                .Include(x => x.Wallet)
                .Include(x => x.HistoryPoints)
                .FirstOrDefault();
        }
    }
}
