using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class User : IActivatable
    {
        public Guid UserId { get; set; }
        public int? TerminalId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public virtual Terminal? Terminal { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<HistoryPoint>? HistoryPoints { get; set; }
        public virtual ICollection<WalletUser>? WalledByUsers { get; set; }
        public virtual ICollection<Driver>? Drivers { get; set; }
        public virtual ICollection<Provider>? Providers { get; set; }
        public virtual ICollection<TerminalOperator>? TerminalOperators { get; set; }
        public virtual ICollection<HistoryPoint>? CreatedHistoryPoints { get; set; }
        public virtual ICollection<HistoryPoint>? UpdatedHistoryPoints { get; set; }
        public virtual ICollection<SuperPowerUser>? CreatedSuperPowerByUserList { get; set; }
        public virtual ICollection<SuperPowerUser>? UpdatedSuperPowerByUserList { get; set; }
        public virtual ICollection<SuperPowerUser>? SuperPowers { get; set; }
        public virtual ICollection<HistoryAppointment>? CreatedHistoryAppointments { get; set; }
        public virtual ICollection<HistoryAppointment>? UpdatedHistoryAppointments { get; set; }
        public virtual ICollection<Appointment>? CreatedAppointments { get; set; }
        public virtual ICollection<Appointment>? UpdatedAppointments { get; set; }
        public virtual ICollection<Mission>? CreatedMissions { get; set; }
        public virtual ICollection<Mission>? UpdatedMissions { get; set; }

    }
}
