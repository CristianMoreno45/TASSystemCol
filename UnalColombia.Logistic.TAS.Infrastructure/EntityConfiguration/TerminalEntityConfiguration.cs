using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class TerminalEntityConfiguration : IEntityTypeConfiguration<Terminal>
    {
        public void Configure(EntityTypeBuilder<Terminal> entity)
        {
            entity.HasKey(e => e.TerminalId);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(e => e.Operator)
                .WithMany(o => o.Terminals)
                .HasForeignKey(e => e.OperatorId);

            entity.HasOne(e => e.City)
                .WithMany(c => c.Terminals)
                .HasForeignKey(e => e.GeographicLocationCityId);

            entity.HasMany(e => e.AppointmentStates)
                .WithOne(a => a.Terminal)
                .HasForeignKey(e => e.TerminalId)
                .IsRequired(false);

            entity.HasMany(e => e.Locations)
                .WithOne(a => a.Terminal)
                .HasForeignKey(e => e.TerminalId)
                .IsRequired(false);

            entity.HasMany(e => e.Users)
                .WithOne(a => a.Terminal)
                .HasForeignKey(e => e.TerminalId)
                .IsRequired(false);

            entity.HasMany(e => e.Calendars)
                .WithOne(a => a.Terminal)
                .HasForeignKey(e => e.TerminalId)
                .IsRequired(false);
        }
    }
}
