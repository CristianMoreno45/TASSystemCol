using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class IdentificationTypeEntityConfiguration : IEntityTypeConfiguration<IdentificationType>
    {
        public void Configure(EntityTypeBuilder<IdentificationType> entity)
        {

            entity.HasKey(e => e.IdentificationTypeId);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Code1)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Code2)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Code3)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasMany(e => e.Drivers)
              .WithOne(a => a.IdentificationType)
              .HasForeignKey(e => e.IdentificationTypeId)
              .IsRequired(false);
        }
    }
}
