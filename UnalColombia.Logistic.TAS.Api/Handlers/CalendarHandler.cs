using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Shared.Requests.Calendar;
using UnalColombia.Logistic.TAS.Shared.Responses.Calendar;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class CalendarHandler: ICalendarHandler
    {
        private readonly ILogger _logger;
        private readonly ICalendarRepository _calendarRepository;

        public CalendarHandler(ILogger logger, ICalendarRepository calendarRepository)
        {
            _logger = logger;
            _calendarRepository = calendarRepository;
        }

        public GetCalendarListByTerminalIdResponse GetCalendarListByTerminalId(GetCalendarListByTerminalIdRequest request)
        {
            var calendars = _calendarRepository
                .GetByFilter(x => 
                    x.TerminalId == request.TerminalId 
                    && x.IsActive).ToList();
            return new GetCalendarListByTerminalIdResponse() { CalendarList = calendars };
        }
    }

}
