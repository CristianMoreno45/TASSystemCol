using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class SuperPowerUser : IActivatable, IAuditable
    {
        public Guid SuperPowerId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public Guid? LastUpdatedUserId { get; set; }
        public virtual DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual User User { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual User? UpdatedByUser { get; set; }
        public virtual ICollection<HistoryPoint>? HistoryAppliedPoints { get; set; }
    }
}
