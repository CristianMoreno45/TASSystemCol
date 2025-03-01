using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Shared.Requests.User;
using UnalColombia.Logistic.TAS.Shared.Responses.User;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class UserHandler : IUserHandler
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;

        public UserHandler(ILogger logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public GetUserByUsernameAndPaswordResponse GetUserByUsernameAndPasword(GetUserByUsernameAndPaswordRequest request)
        {
            var appointmentState = _userRepository
                .GetByFilter(x =>
                    x.UserName == request.UserName
                    && x.Password == request.Password
                    && x.IsActive).FirstOrDefault();
            if (appointmentState == null) throw new Exception("Credenciales invalidas");
            appointmentState.Password = "";
            return new GetUserByUsernameAndPaswordResponse() { UserInfo = appointmentState };
        }
    }

}
