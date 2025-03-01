
using Microsoft.AspNetCore.Mvc;
using UnalColombia.Common.Dtos;
using UnalColombia.Logistic.TAS.Api.Handlers;
using UnalColombia.Logistic.TAS.Shared.Requests.City;
using UnalColombia.Logistic.TAS.Shared.Responses.City;

namespace UnalColombia.Logistic.TAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityHandler _service;

        public CityController(ICityHandler service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("GetCitiesByStateId")]
        public IActionResult GetCitiesByStateId(GetCitiesByStateIdRequest request)
        {
            var result = _service.GetCitiesByStateId(request);
            var response = new Response<GetCitiesByStateIdResponse>() { Data = result };
            return Ok(response);
        }
    }

}






