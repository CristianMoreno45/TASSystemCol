using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class SuperPowerUserEntityConfiguration : IEntityTypeConfiguration<SuperPowerUser>
    {
        public void Configure(EntityTypeBuilder<SuperPowerUser> entity)
        {
            entity.HasKey(e => new { e.SuperPowerId, e.UserId });

            entity.Property(e => e.EndDate)
                .HasColumnType("datetime2")
                .IsRequired();

            entity.HasOne(e => e.User)
               .WithMany(u => u.SuperPowers)
               .HasForeignKey(e => e.UserId);

            entity.HasOne(e => e.CreatedByUser)
               .WithMany(u => u.CreatedSuperPowerByUserList)
               .HasForeignKey(e => e.CreatedUserId);

            entity.HasOne(e => e.UpdatedByUser)
                 .WithMany(u => u.UpdatedSuperPowerByUserList)
                .HasForeignKey(e => e.LastUpdatedUserId)
                .IsRequired(false);

            entity.HasMany(e => e.HistoryAppliedPoints)
                .WithOne(a => a.SuperPowerByUser)
                .HasForeignKey(e => new { e.UserId, e.SuperPowerId })
                .IsRequired(false);
        }
    }
}
