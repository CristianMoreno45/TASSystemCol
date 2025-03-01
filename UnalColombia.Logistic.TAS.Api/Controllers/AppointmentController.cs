
using Microsoft.AspNetCore.Mvc;
using UnalColombia.Common.Dtos;
using UnalColombia.Logistic.TAS.Api.Handlers;
using UnalColombia.Logistic.TAS.Shared.Requests.Appointment;
using UnalColombia.Logistic.TAS.Shared.Responses.Appointment;

namespace UnalColombia.Logistic.TAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentHandler _service;

        public AppointmentController(IAppointmentHandler service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("ReserveAppointment")]
        public async Task<IActionResult> ReserveAppointment(ReserveAppointmentRequest request)
        {
            var result = await _service.ReserveAppointment(request);
            var response = new Response<Guid>() { Data = result };
            return Ok(response);
        }

        [HttpPost]
        [Route("GetAllInformationById")]
        public async Task<IActionResult> GetAllInformationById(GetAllInformationByIdRequest request)
        {
            var result =  _service.GetAllInformationById(request);
            var response = new Response<GetAllInformationByIdResponse>() { Data = result };
            return Ok(response);
        }

        [HttpPost]
        [Route("GetSummaryAppointmentList")]
        public async Task<IActionResult> GetSummaryAppointmentList(GetSummaryAppointmentListRequest request)
        {
            var result = await _service.GetSummaryAppointmentList(request);
            var response = new Response<GetSummaryAppointmentListResponse>() { Data = result };
            return Ok(response);
        }

        [HttpPost]
        [Route("GetAppointmentsByUserId")]
        public async Task<IActionResult> GetAppointmentsByUserId(GetAppointmentsByUserIdRequest request)
        {
            var result = await _service.GetAppointmentsByUserId(request);
            var response = new Response<GetAppointmentsByUserIdResponse>() { Data = result };
            return Ok(response);
        }
    }
}






