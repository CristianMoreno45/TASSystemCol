using UnalColombia.Logistic.TAS.Domain.Entities;

namespace UnalColombia.Logistic.TAS.Shared.Responses.WalletUser
{
    public class GetBalanceAndHistoryByUserIdResponse
    {
        public List<GetBalanceAndHistoryByUserIdItemResponse> Wallets { get; set; }
    }

    public class GetBalanceAndHistoryByUserIdItemResponse
    {
        public Guid WalletId { get; set; }
        public string WalletName { get; set; }
        public Guid UserId { get; set; }
        public decimal Balance { get; set; }
        public List<HistoryPoint> HistoryList { get; set; }
    }
}
