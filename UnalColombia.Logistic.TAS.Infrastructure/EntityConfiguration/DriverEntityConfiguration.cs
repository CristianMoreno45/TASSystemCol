using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class DriverEntityConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> entity)
        {
            entity.HasKey(e => e.DriverId);
            entity.HasIndex(e => e.LicenceNumber)
                .IsUnique();

            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.LicenceNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IdentificationNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(e => e.User)
                .WithMany(u => u.Drivers)
                .HasForeignKey(e => e.UserId);

            entity.HasOne(e => e.IdentificationType)
                .WithMany(i => i.Drivers)
                .HasForeignKey(e => e.IdentificationTypeId);
        }
    }
}
