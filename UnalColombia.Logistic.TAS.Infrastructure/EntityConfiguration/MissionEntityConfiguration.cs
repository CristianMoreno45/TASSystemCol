using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class MissionEntityConfiguration : IEntityTypeConfiguration<Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> entity)
        {

            entity.HasKey(e => e.MissionId);

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Points)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            entity.HasOne(e => e.CreatedByUser)
                 .WithMany(a => a.CreatedMissions)
                 .HasForeignKey(e => e.CreatedUserId);

            entity.HasOne(e => e.UpdatedByUser)
                 .WithMany(a => a.UpdatedMissions)
                 .HasForeignKey(e => e.LastUpdatedUserId)
                 .IsRequired(false);

            entity.HasMany(e => e.MissionAppointmets)
                .WithOne(a => a.Mission)
                .HasForeignKey(e => e.MissionId)
                .IsRequired(false);
        }
    }
}
