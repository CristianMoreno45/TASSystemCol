using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class OperatorEntityConfiguration : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> entity)
        {

            entity.HasKey(e => e.OperatorId);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasMany(e => e.Terminals)
               .WithOne(a => a.Operator)
               .HasForeignKey(e => e.OperatorId)
               .IsRequired(false);
        }
    }
}
