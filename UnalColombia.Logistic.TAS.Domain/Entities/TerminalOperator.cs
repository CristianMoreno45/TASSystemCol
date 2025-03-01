using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class TerminalOperator : IActivatable
    {
        public Guid TerminalOperatorId { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual User User { get; set; }

    }
}
