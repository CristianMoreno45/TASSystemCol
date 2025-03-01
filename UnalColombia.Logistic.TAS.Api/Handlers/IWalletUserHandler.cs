using UnalColombia.Logistic.TAS.Shared.Requests.WalletUser;
using UnalColombia.Logistic.TAS.Shared.Responses.WalletUser;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface IWalletUserHandler
    {
        GetBalanceAndHistoryByUserIdResponse GetBalanceAndHistoryByUserId(GetBalanceAndHistoryByUserIdRequest request);
        Task<bool> DepositPoints(Guid walledId, Guid userId, decimal points, string mission, Guid? superPowerId = null);
    }
}