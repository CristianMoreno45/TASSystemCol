using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class Driver : IActivatable
    {
        public Guid DriverId { get; set; }
        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string LicenceNumber { get; set; }
        public int IdentificationTypeId { get; set; }
        public string IdentificationNumber { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }

        public virtual User User { get; set; }
        public virtual IdentificationType IdentificationType { get; set; }
        public virtual ICollection<HistoryAppointment>? HistoryAppointments { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }


    }
}
