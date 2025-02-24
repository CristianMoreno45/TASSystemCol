using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class Calendar : IActivatable
    {
        public Guid CalendarId { get; set; }
        public int TerminalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public bool HasOverlaping { get; set; }
        public bool IsActive { get; set; }

        public virtual Terminal Terminal { get; set; }
        public virtual ICollection<DayOfWeekSettings>? DayOfWeekSettings { get; set; }
        public virtual ICollection<DeadBand>? DeadBands { get; set; }
        public virtual ICollection<HistoryAppointment>? HistoryAppointments { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }


    }

}
