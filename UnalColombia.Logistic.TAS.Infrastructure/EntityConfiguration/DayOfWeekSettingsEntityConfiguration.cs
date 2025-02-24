using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class DayOfWeekSettingsEntityConfiguration : IEntityTypeConfiguration<DayOfWeekSettings>
    {
        public void Configure(EntityTypeBuilder<DayOfWeekSettings> entity)
        {
            entity.HasKey(e => e.SettingDayOfWeekId);

            entity.Property(e => e.StartTime)
                .HasColumnType("time")
                .IsRequired();

            entity.Property(e => e.FinishTime)
                .HasColumnType("time")
                .IsRequired();

            entity.Property(e => e.DayOfWeek)
                .IsRequired();
            entity.HasOne(e => e.Calendar)
                .WithMany(c => c.DayOfWeekSettings)
                .HasForeignKey(e => e.CalendarId);
        }
    }
}
