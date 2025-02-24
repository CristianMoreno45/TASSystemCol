using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> entity)
        {
            entity.HasKey(e => e.CityId);

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

            entity.HasOne(e => e.State)
                .WithMany(s => s.Cities)
                .HasForeignKey(e => e.StateId);

            entity.HasMany(e => e.Terminals)
               .WithOne(s => s.City)
               .HasForeignKey(e => e.TerminalId);
        }
    }
}
