
using Microsoft.AspNetCore.Mvc;
using UnalColombia.Common.Dtos;
using UnalColombia.Logistic.TAS.Api.Handlers;
using UnalColombia.Logistic.TAS.Shared.Requests.AppointmentState;
using UnalColombia.Logistic.TAS.Shared.Responses.AppointmentState;

namespace UnalColombia.Logistic.TAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentStateController : ControllerBase
    {
        private readonly IAppointmentStateHandler _service;

        public AppointmentStateController(IAppointmentStateHandler service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("GetAppointmentStatesByTerminaId")]
        public IActionResult GetAppointmentStatesByTerminaId(GetAppointmentStatesByTerminaIdRequest request)
        {
            var result = _service.GetAppointmentStatesByTerminaId(request);
            var response = new Response<GetAppointmentStatesByTerminaIdResponse>() { Data = result };
            return Ok(response);
        }
    }
}






