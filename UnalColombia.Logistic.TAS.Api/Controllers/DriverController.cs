
using Microsoft.AspNetCore.Mvc;
using UnalColombia.Common.Dtos;
using UnalColombia.Logistic.TAS.Api.Handlers;
using UnalColombia.Logistic.TAS.Shared.Requests.Driver;
using UnalColombia.Logistic.TAS.Shared.Responses.Driver;

namespace UnalColombia.Logistic.TAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverHandler _service;

        public DriverController(IDriverHandler service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("GetDriverByUserId")]
        public IActionResult GetDriverByUserId(GetDriverByUserIdRequest request)
        {
            var result = _service.GetDriverByUserId(request);
            var response = new Response<GetDriverByUserIdResponse>() { Data = result };
            return Ok(response);
        }
    }
}






