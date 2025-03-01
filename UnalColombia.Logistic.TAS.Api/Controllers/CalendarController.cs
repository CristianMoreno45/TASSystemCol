
using Microsoft.AspNetCore.Mvc;
using UnalColombia.Common.Dtos;
using UnalColombia.Logistic.TAS.Api.Handlers;
using UnalColombia.Logistic.TAS.Shared.Requests.Calendar;
using UnalColombia.Logistic.TAS.Shared.Responses.Calendar;

namespace UnalColombia.Logistic.TAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarHandler _service;

        public CalendarController(ICalendarHandler service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("GetCalendarListByTerminalId")]
        public IActionResult GetCalendarListByTerminalIdRequest(GetCalendarListByTerminalIdRequest request)
        {
            var result = _service.GetCalendarListByTerminalId(request);
            var response = new Response<GetCalendarListByTerminalIdResponse>() { Data = result };
            return Ok(response);
        }
    }
}






