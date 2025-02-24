using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class HistoryAppointmentEntityConfiguration : IEntityTypeConfiguration<HistoryAppointment>
    {
        public void Configure(EntityTypeBuilder<HistoryAppointment> entity)
        {
            entity.HasKey(e => e.HistoryAppointmentId);

            entity.Property(e => e.Title)
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

            entity.HasOne(e => e.Appointment)
                .WithMany(a => a.HistoryAppointments)
                .HasForeignKey(e => e.AppointmentId)
                .IsRequired(false);

            entity.HasOne(e => e.AppointmentState)
                .WithMany(a => a.HistoryAppointments)
                .HasForeignKey(e => e.AppointmentStateId)
                .IsRequired(false);

            entity.HasOne(e => e.Location)
                .WithMany(a => a.HistoryAppointments)
                .HasForeignKey(e => e.LocationId)
                .IsRequired(false);

            entity.HasOne(e => e.Provider)
                .WithMany(a => a.HistoryAppointments)
                .HasForeignKey(e => e.ProviderId)
                .IsRequired(false);

            entity.HasOne(e => e.Driver)
                 .WithMany(a => a.HistoryAppointments)
                 .HasForeignKey(e => e.DriverId)
                 .IsRequired(false);

            entity.HasOne(e => e.Calendar)
                .WithMany(a => a.HistoryAppointments)
                .HasForeignKey(e => e.CalendarId)
                .IsRequired(false);


            entity.HasOne(e => e.CreatedByUser)
                .WithMany(u => u.CreatedHistoryAppointments)
                .HasForeignKey(e => e.CreatedUserId);

            entity.HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.UpdatedHistoryAppointments)
                .HasForeignKey(e => e.LastUpdatedUserId)
                .IsRequired(false);
        }
    }
}
