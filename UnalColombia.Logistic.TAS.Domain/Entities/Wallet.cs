using UnalColombia.Common.Interfaces;

namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class Wallet : IActivatable
    {
        public Guid WalletId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<WalletUser>? WalledByUsers { get; set; }
    }
}
