using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class TypeContainer : IActivatable
    {
        public int TypeContainerId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<CargoInformation>? CargoInformation { get; set; }
    }
}