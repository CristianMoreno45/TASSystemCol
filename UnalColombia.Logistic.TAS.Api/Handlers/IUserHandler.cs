using UnalColombia.Logistic.TAS.Shared.Requests.User;
using UnalColombia.Logistic.TAS.Shared.Responses.User;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface IUserHandler
    {
        GetUserByUsernameAndPaswordResponse GetUserByUsernameAndPasword(GetUserByUsernameAndPaswordRequest request);
    }
}