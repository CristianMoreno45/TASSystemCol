using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class ProviderEntityConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> entity)
        {
            entity.HasKey(e => e.ProviderId);
            entity.HasIndex(e => e.FiscalNumber)
                .IsUnique();

            entity.Property(e => e.FiscalNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FiscalAddress)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.ContactName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ContactPhone)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(e => e.User)
               .WithMany(u => u.Providers)
               .HasForeignKey(e => e.UserId);

            entity.HasMany(e => e.HistoryAppointments)
                .WithOne(a => a.Provider)
                .HasForeignKey(e => e.ProviderId)
                .IsRequired(false);

            entity.HasMany(e => e.Appointments)
                .WithOne(a => a.Provider)
                .HasForeignKey(e => e.ProviderId)
                .IsRequired(false);
        }
    }
}
