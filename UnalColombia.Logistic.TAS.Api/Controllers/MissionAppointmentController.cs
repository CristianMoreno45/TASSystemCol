
using Microsoft.AspNetCore.Mvc;
using UnalColombia.Common.Dtos;
using UnalColombia.Logistic.TAS.Api.Handlers;
using UnalColombia.Logistic.TAS.Shared.Requests.MissionAppointment;

namespace UnalColombia.Logistic.TAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionAppointmentController : ControllerBase
    {
        private readonly IMissionAppointmentHandler _service;

        public MissionAppointmentController(IMissionAppointmentHandler service)
        {
            _service = service;
        }

        [HttpPut]
        [Route("SetComplaingStatusMission")]
        public async Task<IActionResult> SetComplaingStatusMission(SetComplaingStatusMissionRequest request)
        {
            var result = await _service.SetComplaingStatusMission(request);
            var response = new Response<bool>() { Data = result };
            return Ok(response);
        }
    }

}






