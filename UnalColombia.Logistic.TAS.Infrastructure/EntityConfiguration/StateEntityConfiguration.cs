using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class StateEntityConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> entity)
        {

            entity.HasKey(e => e.StateId);

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

            entity.HasMany(e => e.Cities)
               .WithOne(s => s.State)
               .HasForeignKey(e => e.StateId);
        }
    }
}
