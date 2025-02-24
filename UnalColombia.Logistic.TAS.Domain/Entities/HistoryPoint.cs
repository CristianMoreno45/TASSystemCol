using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class HistoryPoint : IActivatable, IAuditable
    {
        public Guid PointHistoryId { get; set; }
        public Guid UserId { get; set; }
        public Guid WalletId { get; set; }
        public Guid SuperPowerId { get; set; }

        public string Description { get; set; }
        public decimal Points { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public Guid? LastUpdatedUserId { get; set; }

        public bool IsActive { get; set; }

        public virtual User User { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual User? UpdatedByUser { get; set; }
        public virtual WalletUser WalledUser { get; set; }
        public virtual SuperPowerUser? SuperPowerByUser { get; set; }

    }
}
