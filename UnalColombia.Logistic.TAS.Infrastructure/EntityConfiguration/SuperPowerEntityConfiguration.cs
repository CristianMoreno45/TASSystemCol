using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class SuperPowerEntityConfiguration : IEntityTypeConfiguration<SuperPower>
    {
        public void Configure(EntityTypeBuilder<SuperPower> entity)
        {
            entity.HasKey(e => e.SuperPowerId);

            entity.Property(e => e.MultiplierFactor)
                .HasColumnType("decimal(5,2)");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(e => e.CreatedByUser)
                .WithMany(u => u.CreatedSuperPowers)
                .HasForeignKey(e => e.CreatedUserId);

            entity.HasOne(e => e.UpdatedByUser)
                .WithMany(u => u.UpdatedSuperPowers)
                .HasForeignKey(e => e.LastUpdatedUserId)
                .IsRequired(false);


        }
    }
}
