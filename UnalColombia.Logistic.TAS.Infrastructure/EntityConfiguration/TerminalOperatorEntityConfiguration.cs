using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class TerminalOperatorEntityConfiguration : IEntityTypeConfiguration<TerminalOperator>
    {
        public void Configure(EntityTypeBuilder<TerminalOperator> entity)
        {
            entity.HasKey(e => e.TerminalOperatorId);

            entity.HasOne(e => e.User)
                .WithMany(u => u.TerminalOperators)
                .HasForeignKey(e => e.UserId);
        }
    }
}
