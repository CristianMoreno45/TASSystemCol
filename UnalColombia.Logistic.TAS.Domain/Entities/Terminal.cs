using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class Terminal : IActivatable
    {
        public int TerminalId { get; set; }
        public long OperatorId { get; set; }
        public string Name { get; set; }
        public string? Url { get; set; }
        public int GeographicLocationCityId { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual Operator Operator { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<AppointmentState>? AppointmentStates { get; set; }
        public virtual ICollection<Location>? Locations { get; set; }
        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Calendar>? Calendars { get; set; }
    }
}