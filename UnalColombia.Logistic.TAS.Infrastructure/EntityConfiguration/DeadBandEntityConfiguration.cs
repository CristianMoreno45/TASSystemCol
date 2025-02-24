using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class DeadBandEntityConfiguration : IEntityTypeConfiguration<DeadBand>
    {
        public void Configure(EntityTypeBuilder<DeadBand> entity)
        {
            entity.HasKey(e => e.DeadBandId);

            entity.Property(e => e.Reason)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.StartTime)
                .HasColumnType("time")
                .IsRequired();

            entity.Property(e => e.FinishTime)
                .HasColumnType("time")
                .IsRequired();

            entity.Property(e => e.RecurrentPattern)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(e => e.Calendar)
                .WithMany(c => c.DeadBands)
                .HasForeignKey(e => e.CalendarId);
        }
    }
}
