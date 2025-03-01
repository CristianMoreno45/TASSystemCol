using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class Operator : IActivatable
    {
        public long OperatorId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ICollection<Terminal>? Terminals { get; set; }

    }
}
