using UnalColombia.Logistic.TAS.Domain.Entities;

namespace UnalColombia.Logistic.TAS.Shared.Responses.Calendar
{
    public class GetCalendarListByTerminalIdResponse
    {
        public List<Domain.Entities.Calendar>? CalendarList { get; set; }

    }

}
