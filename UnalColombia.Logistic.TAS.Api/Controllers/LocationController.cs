
using Microsoft.AspNetCore.Mvc;
using UnalColombia.Common.Dtos;
using UnalColombia.Logistic.TAS.Api.Handlers;
using UnalColombia.Logistic.TAS.Shared.Requests.Location;
using UnalColombia.Logistic.TAS.Shared.Responses.Location;

namespace UnalColombia.Logistic.TAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationHandler _service;

        public LocationController(ILocationHandler service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("GetLocationsByTerminalId")]
        public IActionResult GetLocationsByTerminalId(GetLocationsByTerminalIdRequest request)
        {
            var result = _service.GetLocationsByTerminalId(request);
            var response = new Response<GetLocationsByTerminalIdResponse>() { Data = result };
            return Ok(response);
        }
    }
}






