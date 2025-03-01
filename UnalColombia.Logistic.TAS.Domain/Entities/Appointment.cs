using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class Appointment : IActivatable, IAuditable
    {
        public Guid AppointmentId { get; set; }
        public int AppointmentStateId { get; set; }
        public int LocationId { get; set; }
        public Guid ProviderId { get; set; }
        public Guid DriverId { get; set; }
        public Guid CalendarId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }

        public DateTime CreatedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public Guid? LastUpdatedUserId { get; set; }
        public bool IsActive { get; set; }

        public virtual AppointmentState AppointmentState { get; set; }
        public virtual Location Location { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Calendar Calendar { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual User? UpdatedByUser { get; set; }

        public virtual ICollection<MissionAppointmet> MissionAppointmets { get; set; }
        public virtual ICollection<HistoryAppointment>? HistoryAppointments   { get; set; }
        public virtual ICollection<CargoInformation> CargoInformation   { get; set; }
    }
}