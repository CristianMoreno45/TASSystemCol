using UnalColombia.Logistic.TAS.Shared.Requests.Calendar;
using UnalColombia.Logistic.TAS.Shared.Responses.Calendar;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public interface ICalendarHandler
    {
        GetCalendarListByTerminalIdResponse GetCalendarListByTerminalId(GetCalendarListByTerminalIdRequest request);
    }

}
