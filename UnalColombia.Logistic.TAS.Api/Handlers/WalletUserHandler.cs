using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Shared.Requests.WalletUser;
using UnalColombia.Logistic.TAS.Shared.Responses.WalletUser;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class WalletUserHandler : IWalletUserHandler
    {
        private readonly ILogger _logger;
        private readonly IWalletUserRepository _walletUserRepository;
        private readonly ISuperPowerHandler _superPowerService;

        public WalletUserHandler(ILogger logger, IWalletUserRepository walletUserRepository, ISuperPowerHandler superPowerHandler)
        {
            _logger = logger;
            _walletUserRepository = walletUserRepository;
            _superPowerService = superPowerHandler;
        }

        public GetBalanceAndHistoryByUserIdResponse GetBalanceAndHistoryByUserId(GetBalanceAndHistoryByUserIdRequest request)
        {
            var response = new GetBalanceAndHistoryByUserIdResponse()
            {
                Wallets = new List<GetBalanceAndHistoryByUserIdItemResponse>()
            };
            var wallets = _walletUserRepository.GetWalletsByUser(request.UserId);
            if (wallets == null) return response;
            foreach (var wallet in wallets)
            {
                var history = wallet.HistoryPoints == null ? [] : wallet.HistoryPoints.ToList();
                response.Wallets.Add(new GetBalanceAndHistoryByUserIdItemResponse()
                {
                    WalletId = wallet.WalletId,
                    WalletName = wallet.Wallet.Name,
                    Balance = wallet.Balance,
                    UserId = request.UserId,
                    HistoryList = history,
                });
            }

            return response;
        }


        public async Task<bool> DepositPoints(Guid walledId, Guid userId, decimal points, string mission, Guid? superPowerId = null)
        {
            if (points <= 0) return false;
            var wallet = _walletUserRepository.GetWalletsByUserAndWalled(userId, walledId);
            if (wallet == null) return false;

            if (superPowerId != null)
            {
                var superpower = await _superPowerService.GetSuperPowerById((Guid)superPowerId);
                points = points * (1 + superpower.MultiplierFactor);
            }
            wallet.Balance += points;
            //HistoryPoint record = new HistoryPoint()
            //{
            //    CreatedUserId = userId,
            //    CreatedDate = DateTime.UtcNow,
            //    Description = mission,
            //    Points = points,
            //    IsActive = true
            //}; 
            
            //if (superPowerId != null)
            //    record.SuperPowerId = (Guid)superPowerId;
            
            //if (wallet.HistoryPoints == null)
            //    wallet.HistoryPoints = new List<HistoryPoint>();
            //wallet.HistoryPoints.Add(record);

            return true;
        }

    }


}
