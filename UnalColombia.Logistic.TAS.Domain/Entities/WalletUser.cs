namespace UnalColombia.Logistic.TAS.Domain.Entities
{
    public class WalletUser
    {
        public Guid WalletId { get; set; }
        public Guid UserId { get; set; } 
        public decimal Balance { get; set; }

        public virtual User User { get; set; }
        public virtual Wallet Wallet { get; set; }
        public virtual ICollection<HistoryPoint>? HistoryPoints { get; set; }

    }
}
