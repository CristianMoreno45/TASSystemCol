using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class ISOCountryEntityConfiguration : IEntityTypeConfiguration<ISOCountry>
    {
        public void Configure(EntityTypeBuilder<ISOCountry> entity)
        {

            entity.HasKey(e => e.ISOCountryId);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.A2)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.A3)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasMany(e => e.OriginCargoInformationList)
                .WithOne(a => a.GeographicalLocationOrigin)
                .HasForeignKey(e => e.GeographicalLocationOriginISOCountryId)
                .IsRequired(false);

            entity.HasMany(e => e.DestinationCargoInformationList)
              .WithOne(a => a.GeographicalLocationDestination)
              .HasForeignKey(e => e.GeographicalLocationDestinationISOCountryId)
              .IsRequired(false);
        }
    }
}
