
using Microsoft.AspNetCore.Mvc;
using UnalColombia.Common.Dtos;
using UnalColombia.Logistic.TAS.Api.Handlers;
using UnalColombia.Logistic.TAS.Shared.Requests.User;
using UnalColombia.Logistic.TAS.Shared.Responses.User;

namespace UnalColombia.Logistic.TAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserHandler _service;

        public UserController(IUserHandler service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("GetUserByUsernameAndPasword")]
        public IActionResult GetUserByUsernameAndPasword(GetUserByUsernameAndPaswordRequest request)
        {
            var result = _service.GetUserByUsernameAndPasword(request);
            var response = new Response<GetUserByUsernameAndPaswordResponse>() { Data = result };
            return Ok(response);
        }
    }
}






