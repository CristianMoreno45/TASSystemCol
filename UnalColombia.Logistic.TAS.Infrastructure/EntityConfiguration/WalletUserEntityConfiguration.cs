using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class WalletUserEntityConfiguration : IEntityTypeConfiguration<WalletUser>
    {
        public void Configure(EntityTypeBuilder<WalletUser> entity)
        {
            entity.HasKey(e => new { e.WalletId, e.UserId });

            entity.Property(e => e.Balance)
                .HasColumnType("decimal(18,2)");

            entity.HasOne(e => e.User)
               .WithMany(u => u.WalledByUsers)
               .HasForeignKey(e => e.UserId);


            entity.HasOne(e => e.Wallet)
                .WithMany(w => w.WalledByUsers)
                .HasForeignKey(e => e.WalletId);

            entity.HasMany(e => e.HistoryPoints)
               .WithOne(a => a.WalledUser)
               .HasForeignKey(e => new { e.UserId, e.WalletId })
               .IsRequired(false);
        }
    }
}
