using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class CalendarEntityConfiguration : IEntityTypeConfiguration<Calendar>
    {
        public void Configure(EntityTypeBuilder<Calendar> entity)
        {
            entity.HasKey(e => e.CalendarId);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.StartTime)
                .HasColumnType("time");

            entity.Property(e => e.FinishTime)
                .HasColumnType("time");

            entity.HasOne(e => e.Terminal)
                .WithMany(t => t.Calendars)
                .HasForeignKey(e => e.TerminalId);

            entity.HasMany(e => e.DayOfWeekSettings)
                .WithOne(t => t.Calendar)
                .HasForeignKey(e => e.SettingDayOfWeekId)
                .IsRequired(false);

            entity.HasMany(e => e.DeadBands)
               .WithOne(t => t.Calendar)
               .HasForeignKey(e => e.DeadBandId)
               .IsRequired(false);
        }
    }
}
