using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class TypeContainerEntityConfiguration : IEntityTypeConfiguration<TypeContainer>
    {
        public void Configure(EntityTypeBuilder<TypeContainer> entity)
        {
            entity.HasKey(e => e.TypeContainerId);

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasMany(e => e.CargoInformation)
                .WithOne(a => a.TypeContainer)
                .HasForeignKey(e => e.TypeContainerId)
                .IsRequired(false);
        }
    }
}
