using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class DayOfWeekSettings : IActivatable
    {
        public int SettingDayOfWeekId { get; set; }
        public Guid CalendarId { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Calendar Calendar { get; set; }
    }

}
