using UnalColombia.Common.Infrastructure;

namespace UnalColombia.Logistic.TAS.Domain.Repositories
{
    public interface IWalletUserRepository : IRepositoryAsync<Entities.WalletUser>
    {
        IEnumerable<Domain.Entities.WalletUser> GetWalletsByUser(Guid userId);
        Domain.Entities.WalletUser? GetWalletsByUserAndWalled(Guid userId, Guid walletId);
    }
}
