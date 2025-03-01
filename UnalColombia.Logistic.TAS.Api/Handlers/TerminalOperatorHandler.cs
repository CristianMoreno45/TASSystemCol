using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Shared.Requests.TerminalOperator;
using UnalColombia.Logistic.TAS.Shared.Responses.TerminalOperator;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class TerminalOperatorHandler : ITerminalOperatorHandler
    {
        private readonly ILogger _logger;
        private readonly ITerminalOperatorRepository _terminalOperatorRepository;

        public TerminalOperatorHandler(ILogger logger, ITerminalOperatorRepository terminalOperatorRepository)
        {
            _logger = logger;
            _terminalOperatorRepository = terminalOperatorRepository;
        }

        public GetTerminalOperatorByUserIdResponse GetTerminalOperatorByUserId(GetTerminalOperatorByUserIdRequest request)
        {
            var terminalOperator = _terminalOperatorRepository
                .GetByFilter(x =>
                    x.UserId == request.UserId
                    && x.IsActive).FirstOrDefault();
            if (terminalOperator == null) terminalOperator = new Domain.Entities.TerminalOperator();
            return new GetTerminalOperatorByUserIdResponse() { TerminalOperatorInfo = terminalOperator };
        }
    }

}
