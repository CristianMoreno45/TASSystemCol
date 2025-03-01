using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class Mission : IActivatable, IAuditable
    {
        public int MissionId { get; set; }

        public string? Description { get; set; }

        
        public decimal Points { get; set; }

        public DateTime CreatedDate { get; set; }
        public Guid CreatedUserId { get; set; } 
        public DateTime? LastUpdatedDate { get; set; }
        public Guid? LastUpdatedUserId { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual User CreatedByUser { get; set; }
        public virtual User? UpdatedByUser { get; set; }
        public virtual ICollection<MissionAppointmet>? MissionAppointmets { get; set; }
    }
}