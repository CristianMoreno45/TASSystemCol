using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class MissionAppointmetEntityConfiguration : IEntityTypeConfiguration<MissionAppointmet>
    {
        public void Configure(EntityTypeBuilder<MissionAppointmet> entity)
        {
            entity.HasKey(e => new { e.MissionId, e.AppointmentId });

            entity.HasOne(e => e.Mission)
                .WithMany(m => m.MissionAppointmets)
                .HasForeignKey(e => e.MissionId);

            entity.HasOne(e => e.Appointment)
                .WithMany(a => a.MissionAppointmets)
                .HasForeignKey(e => e.AppointmentId);
        }
    }
}
