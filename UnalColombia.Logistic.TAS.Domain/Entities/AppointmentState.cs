using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class AppointmentState : IActivatable
    {
        public int AppointmentStateId { get; set; }
        public int TerminalId { get; set; }
        public string Name { get; set; }
        public bool AllowChanges { get; set; }
        public bool IsActive { get; set; }

        public virtual Terminal Terminal { get; set; }
        public virtual ICollection<HistoryAppointment>? HistoryAppointments { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }

    }
}
