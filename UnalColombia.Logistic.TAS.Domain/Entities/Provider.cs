using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class Provider : IActivatable
    {
        public Guid ProviderId { get; set; }
        public Guid UserId { get; set; }
        public string FiscalNumber { get; set; }
        public string FiscalAddress { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<HistoryAppointment>? HistoryAppointments { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }


    }
}
