using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class AppointmentStateEntityConfiguration : IEntityTypeConfiguration<AppointmentState>
    {
        public void Configure(EntityTypeBuilder<AppointmentState> entity)
        {

            entity.HasKey(e => e.AppointmentStateId);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(e => e.Terminal)
                .WithMany()
                .HasForeignKey(e => e.TerminalId);

        }
    }
}
