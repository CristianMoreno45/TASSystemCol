using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class SuperPower : IActivatable, IAuditable
    {
        public Guid SuperPowerId { get; set; }
        public decimal MultiplierFactor { get; set; }
        public string Name { get; set; }
        public int MinutesDuaration { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public Guid? LastUpdatedUserId { get; set; }
        public bool IsActive { get; set; } = false;

        public virtual User CreatedByUser { get; set; }
        public virtual User? UpdatedByUser { get; set; }

    }
}
