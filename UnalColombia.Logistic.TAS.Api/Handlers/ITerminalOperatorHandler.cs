using UnalColombia.Logistic.TAS.Shared.Requests.TerminalOperator;
using UnalColombia.Logistic.TAS.Shared.Responses.TerminalOperator;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface ITerminalOperatorHandler
    {
        GetTerminalOperatorByUserIdResponse GetTerminalOperatorByUserId(GetTerminalOperatorByUserIdRequest request);
    }
}