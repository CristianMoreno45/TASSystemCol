using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class Location : IActivatable
    {
        public int LocationId { get; set; }
        public int TerminalId { get; set; }
        public string Name { get; set; }
        public string? FisicalLocation { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual Terminal Terminal { get; set; }
        public virtual ICollection<HistoryAppointment>? HistoryAppointments { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }

    }
}
