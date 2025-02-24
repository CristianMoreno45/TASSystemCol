using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class CargoInformationEntityConfiguration : IEntityTypeConfiguration<CargoInformation>
    {
        public void Configure(EntityTypeBuilder<CargoInformation> entity)
        {
            entity.HasKey(e => e.CargoInformationId);
            entity.HasIndex(e => e.ContainerId);

            entity.Property(e => e.ContainerId)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LengthInFeet)
                .HasColumnType("decimal(8,2)");

            entity.Property(e => e.HeightInFeet)
                .HasColumnType("decimal(8,2)");

            entity.Property(e => e.WidthInFeet)
                .HasColumnType("decimal(8,2)");

            entity.Property(e => e.GrossWeightInKilos)
                .HasColumnType("decimal(10,2)");

            entity.Property(e => e.NetWeightInKilos)
                .HasColumnType("decimal(10,2)");

            entity.Property(e => e.TypeCargo)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.TractorTrailerRegistrationNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IMOCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.RequiredCelciusTemperature)
                .HasColumnType("decimal(5,2)");

            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(e => e.TypeContainer)
                .WithMany(t => t.CargoInformation)
                .HasForeignKey(e => e.TypeContainerId);

            entity.HasOne(e => e.GeographicalLocationOrigin)
                .WithMany(c => c.OriginCargoInformationList)
                .HasForeignKey(e => e.GeographicalLocationOriginISOCountryId);

            entity.HasOne(e => e.GeographicalLocationDestination)
                .WithMany(c => c.DestinationCargoInformationList)
                .HasForeignKey(e => e.GeographicalLocationDestinationISOCountryId);
        }
    }
}
