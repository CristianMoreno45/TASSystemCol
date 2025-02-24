using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> entity)
        {

            entity.HasKey(e => e.LocationId);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FisicalLocation)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasMany(e => e.HistoryAppointments)
                .WithOne(a => a.Location)
                .HasForeignKey(e => e.LocationId)
                .IsRequired(false);
        }
    }
}
