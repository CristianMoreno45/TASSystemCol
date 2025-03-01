
using Microsoft.AspNetCore.Mvc;
using UnalColombia.Common.Dtos;
using UnalColombia.Logistic.TAS.Api.Handlers;
using UnalColombia.Logistic.TAS.Shared.Requests.WalletUser;
using UnalColombia.Logistic.TAS.Shared.Responses.WalletUser;

namespace UnalColombia.Logistic.TAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletUserController : ControllerBase
    {
        private readonly IWalletUserHandler _service;

        public WalletUserController(IWalletUserHandler service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("GetBalanceAndHistoryByUserId")]
        public IActionResult GetBalanceAndHistoryByUserId(GetBalanceAndHistoryByUserIdRequest request)
        {
            var result = _service.GetBalanceAndHistoryByUserId(request);
            var response = new Response<GetBalanceAndHistoryByUserIdResponse>() { Data = result };
            return Ok(response);
        }
    }

}






