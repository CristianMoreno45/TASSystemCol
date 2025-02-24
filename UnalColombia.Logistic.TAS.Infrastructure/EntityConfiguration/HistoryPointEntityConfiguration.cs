using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class HistoryPointEntityConfiguration : IEntityTypeConfiguration<HistoryPoint>
    {
        public void Configure(EntityTypeBuilder<HistoryPoint> entity)
        {
            entity.HasKey(e => e.PointHistoryId);

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Points)
                .HasColumnType("decimal(10,2)");

            entity.HasOne(e => e.User)
                .WithMany(u => u.HistoryPoints)
                .HasForeignKey(e => e.UserId);

            entity.HasOne(e => e.CreatedByUser)
                .WithMany(u => u.CreatedHistoryPoints)
                .HasForeignKey(e => e.CreatedUserId);

            entity.HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.UpdatedHistoryPoints)
                .HasForeignKey(e => e.LastUpdatedUserId)
                .IsRequired(false);

            entity.HasOne(e => e.WalledUser)
                .WithMany(u => u.HistoryPoints)
                .HasForeignKey(e => new { e.WalletId, e.UserId } );

            entity.HasOne(e => e.SuperPowerByUser)
                .WithMany(u => u.HistoryAppliedPoints)
                .HasForeignKey(e => new { e.UserId, e.SuperPowerId })
                .IsRequired(false);

        }
    }
}
