
using Microsoft.AspNetCore.Mvc;
using UnalColombia.Common.Dtos;
using UnalColombia.Logistic.TAS.Api.Handlers;
using UnalColombia.Logistic.TAS.Shared.Requests.TerminalOperator;
using UnalColombia.Logistic.TAS.Shared.Responses.TerminalOperator;

namespace UnalColombia.Logistic.TAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalOperatorController : ControllerBase
    {
        private readonly ITerminalOperatorHandler _service;

        public TerminalOperatorController(ITerminalOperatorHandler service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("GetTerminalOperatorByUserId")]
        public IActionResult GetTerminalOperatorByUserId(GetTerminalOperatorByUserIdRequest request)
        {
            var result = _service.GetTerminalOperatorByUserId(request);
            var response = new Response<GetTerminalOperatorByUserIdResponse>() { Data = result };
            return Ok(response);
        }
    }
}






