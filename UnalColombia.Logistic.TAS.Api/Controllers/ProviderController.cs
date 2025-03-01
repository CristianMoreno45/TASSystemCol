
using Microsoft.AspNetCore.Mvc;
using UnalColombia.Common.Dtos;
using UnalColombia.Logistic.TAS.Api.Handlers;
using UnalColombia.Logistic.TAS.Shared.Requests.Provider;
using UnalColombia.Logistic.TAS.Shared.Responses.Provider;

namespace UnalColombia.Logistic.TAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderHandler _service;

        public ProviderController(IProviderHandler service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("GetProvidersWithUserInformation")]
        public IActionResult GetProvidersWithUserInformation(GetProvidersWithUserInformationRequest request)
        {
            var result = _service.GetProvidersWithUserInformation(request);
            var response = new Response<GetProvidersWithUserInformationResponse>() { Data = result };
            return Ok(response);
        }
    }
}






