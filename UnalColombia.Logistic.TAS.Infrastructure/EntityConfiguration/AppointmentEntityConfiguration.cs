using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class AppointmentEntityConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> entity)
        {

            entity.HasKey(e => e.AppointmentId);
            entity.HasIndex(e => e.StartTime);
            entity.HasIndex(e => e.FinishTime);

            entity.Property(e => e.AppointmentId)
                .ValueGeneratedOnAdd();

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

            entity.HasOne(e => e.AppointmentState)
                .WithMany(m => m.Appointments)
                .HasForeignKey(e => e.AppointmentStateId);

            entity.HasOne(e => e.Location)
                .WithMany(m => m.Appointments)
                .HasForeignKey(e => e.LocationId);

            entity.HasOne(e => e.Provider)
                .WithMany(m => m.Appointments)
                .HasForeignKey(e => e.ProviderId);

            entity.HasOne(e => e.Driver)
                .WithMany(m => m.Appointments)
                .HasForeignKey(e => e.DriverId);

            entity.HasOne(e => e.Calendar)
                .WithMany(m => m.Appointments)
                .HasForeignKey(e => e.CalendarId);

            entity.HasOne(e => e.CreatedByUser)
                .WithMany(u => u.CreatedAppointments)
                .HasForeignKey(e => e.CreatedUserId);

            entity.HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.UpdatedAppointments)
                .HasForeignKey(e => e.LastUpdatedUserId)
                .IsRequired(false);

            entity.HasMany(e => e.MissionAppointmets)
                .WithOne(a => a.Appointment)
                .HasForeignKey(e => e.AppointmentId);

            entity.HasMany(e => e.HistoryAppointments)
                .WithOne(a => a.Appointment)
                .HasForeignKey(e => e.AppointmentId)
                .IsRequired(false);

            entity.HasMany(e => e.CargoInformation)
               .WithOne(a => a.Appointment)
               .HasForeignKey(e => e.AppointmentId);
        }
    }
}
