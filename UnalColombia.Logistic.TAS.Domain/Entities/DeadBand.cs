using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class DeadBand : IActivatable
    {
        public int DeadBandId { get; set; }
        public Guid CalendarId { get; set; }
        public string Reason { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public bool IsRecurrent { get; set; }
        public string RecurrentPattern { get; set; }
        public bool IsActive { get; set; }

        public virtual Calendar Calendar { get; set; }
    }

}
